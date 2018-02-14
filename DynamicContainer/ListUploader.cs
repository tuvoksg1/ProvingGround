using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using CXUtils.Extensions;
using CXUtils.Logging;
using CXUtils.Startup;

namespace DynamicContainer
{
    public class ListUploader
    {
        public string ReplaceList(string name, string id, string path, string tenantId, string tenantCode)
        {
            //var status = $"Uploading list for {name} from location '{path}' on behalf of {tenantCode}";
            var runtime = ConfigurationSectionLoader.Read<PledgeRuntime>("PledgeRuntime.config") ?? new PledgeRuntime();
            var credentialConfig = ConfigurationSectionLoader.Read<Credential>("Credentials.config") ?? new Credential();
            var credential = Credential.Decrypt(credentialConfig, Constants.Cipher.Decrypt(string.Empty));

            var status = $"Uploading new file for list \"{name}\" from location '{path}' " +
                         $"on behalf of {tenantCode} with u:{credential.UserName} & p:{credential.Password}";

            if (runtime.RemoteSettings == null)
            {
                runtime.RemoteSettings = new RemoteRuntimeSettings
                {
                    PassportServerUrl = "https://passport-cx.maritz.com",
                    PledgeJobClient = "pledge_cli",
                    PledgeJobSecret = "PledgeCLI",
                    PledgeApiScope = "pledgeApi"
                };
            }

            var logger = LogUtility.CreateLogger("ListReplaceTool");
            logger.AddMessage(MessageType.Trace, status);

            return $"{status}{Environment.NewLine}Logging to: \"{logger.LogFile}\"{Environment.NewLine}" + 
                $"Authenticating at: \"{runtime.RemoteSettings.PassportServerUrl}\"";
        }

        private void Upload(string file, string address)
        {
            using (var httpClient = new HttpClient())
            {
                using (var fileStream = File.Open(file, FileMode.Open))
                {
                    var fileInfo = new FileInfo(file);

                    var content = new MultipartFormDataContent
                    {
                        {new StreamContent(fileStream), "\"file\"", $"\"{fileInfo.Name}\""}
                    };

                    var taskUpload = httpClient.PostAsync(address, content).ContinueWith(task =>
                    {
                        if (task.Status == TaskStatus.RanToCompletion)
                        {
                            var response = task.Result;

                            if (response.IsSuccessStatusCode)
                            {
                                Console.WriteLine("File upload completed successfully");
                            }
                            else
                            {
                                Console.WriteLine("List upload failed.");
                                Debug.WriteLine("Response Body: {0}", response.Content.ReadAsStringAsync().Result);
                            }
                        }

                        Console.WriteLine("File upload was aborted");
                    });

                    taskUpload.Wait();
                }
            }
        }
    }
}
