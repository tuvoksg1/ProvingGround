using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace DynamicContainer
{
    [Serializable]
    public class ListUploader
    {
        public string ReplaceList(string name, string id, string path, string tenantId, string tenantCode)
        {
            var status = $"Uploading list for {name} from location '{path}' on behalf of {tenantCode}";

            return status;
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
