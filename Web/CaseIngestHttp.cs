using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Web
{
    public class CaseIngestHttp
    {
        private async Task Start()
        {
            var client = new HttpClient();
            const string userName = "";
            const string password = "";
            
            try
            {
                client.BaseAddress = new Uri("https://caseapiemea.allegiancetech.com/CaseManagement.svc/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent($"username={userName}&password={password}",
                    Encoding.UTF8, "application/x-www-form-urlencoded");
                var response = await client.PostAsync("authenticate", content);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.ReasonPhrase);
                }

                var authResponse = await response.Content.ReadAsFormDataAsync();
                var accessToken = authResponse["token"];
                var userId = authResponse["userId"];

                //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
                var caseRequest = new JObject {{"token", accessToken}};

                response = await client.PostAsJsonAsync("getMobileCaseInboxItems", caseRequest);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.ReasonPhrase);
                }

                var caseData = await response.Content.ReadAsAsync<JObject>();

                if (caseData != null)
                {
                    var countProperty = caseData.Property("TotalNewMessageCount");

                    Console.WriteLine($"Total number of cases found: {countProperty.Value}");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
