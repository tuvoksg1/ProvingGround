using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using CXUtils.Extensions;
using CXUtils.Startup;
using Newtonsoft.Json;

namespace DynamicContainer
{
    internal struct ListInfo
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string File { get; set; }
        public string TenantId { get; set; }
    }

    public class ListUploader
    {
        private const string _type = "type";
        private const string _listId = "listid";
        private const string _name = "name";
        private const string _description = "description";
        private const string _function = "function";
        private const string _separator = "separator";
        private const string _tenantId = "tenantid";

        public string ReplaceList(string name, string id, string path, string tenantId, string tenantCode)
        {
            var runtime = ConfigurationSectionLoader.Read<PledgeRuntime>("PledgeRuntime.config");
            var credentialConfig = ConfigurationSectionLoader.Read<Credential>("Credentials.config");

            if (runtime == null || credentialConfig == null)
            {
                return "Unable to load configuration information";
            }

            var credential = Credential.Decrypt(credentialConfig, Constants.Cipher.Decrypt(string.Empty));
            runtime.RemoteSettings.PledgeApiAddress = ApiHelper.FormatUrl(runtime.RemoteSettings.PledgeApiAddress);

            var status = $"Uploading new file for list \"{name}\" from location '{path}' " +
                            $"on behalf of {tenantCode} with u:{credential.UserName} & p:{credential.Password}";

            var listInfo = new ListInfo
            {
                Id = id,
                Name = name,
                File = path,
                TenantId = tenantId
            };

            var subStatus = string.Empty;

            try
            {
                var uploadTask = Upload(runtime.RemoteSettings, credential, listInfo).ContinueWith(task =>
                {
                    subStatus = task.Result;
                });

                uploadTask.Wait();
            }
            catch (Exception error)
            {
                var builder = new StringBuilder($"{error.Message}*****{error.StackTrace}");
                error = error.InnerException;

                while (error != null)
                {
                    builder.AppendLine($"{error.Message}*****{error.StackTrace}");
                    error = error.InnerException;
                }

                subStatus = builder.ToString();
            }

            return $"{status}{Environment.NewLine}{subStatus}";
        }

        private static async Task<string> Upload(RemoteRuntimeSettings settings, Credential credential, ListInfo listInfo)
        {
            var idResponse = ApiHelper.GetUserToken(settings, credential.UserName, credential.Password, settings.PassportServerUrl);
            var list = await GetList(settings.PledgeApiAddress, idResponse.AccessToken, listInfo.Id, listInfo.TenantId);

            using (var httpClient = new HttpClient { BaseAddress = new Uri(settings.PledgeApiAddress) })
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));
                httpClient.DefaultRequestHeaders.Add(_type, list.Type);
                httpClient.DefaultRequestHeaders.Add(_listId, listInfo.Id);
                httpClient.DefaultRequestHeaders.Add(_name, listInfo.Name);
                httpClient.DefaultRequestHeaders.Add(_description, list.Description);
                httpClient.DefaultRequestHeaders.Add(_function, list.Function);
                httpClient.DefaultRequestHeaders.Add(_separator, list.Separator);
                httpClient.DefaultRequestHeaders.Add(_tenantId, listInfo.TenantId);
                httpClient.SetBearerToken(idResponse.AccessToken);

                using (var fileStream = File.Open(listInfo.File, FileMode.Open))
                {
                    var fileName = Path.GetFileName(listInfo.File);

                    var content = new MultipartFormDataContent
                    {
                        {new StreamContent(fileStream), "\"file\"", $"\"{fileName}\""}
                    };

                    var upload = await httpClient.PostAsync("api/externallist/upload", content);
                    return upload.IsSuccessStatusCode
                        ? "File upload completed successfully"
                        : "List upload failed.";
                }
            }
        }

        private static async Task<ListViewModel> GetList(string apiAddress, string token, string listId, string tenantId)
        {
            using (var client = new HttpClient { BaseAddress = new Uri(apiAddress) })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.SetBearerToken(token);

                var response = await client.GetAsync($"api/externallist/fetch/{listId}/{tenantId}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                var listData = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<ListViewModel>(listData);
                if (list == null) throw new Exception("Unable to deserailize list response data");
                return list;
            }
        }
    }
}
