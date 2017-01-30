using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Web
{
    public class CaseIngestHttp
    {
        public async Task Start()
        {
            var client = new HttpClient();
            const string userName = "bryan.rhodes@maritzcx.com";
            const string password = "Password1";

            //const string userName = "sqgabriel@hotmail.com";
            //const string password = "Porsche986";

            try
            {
                client.BaseAddress = new Uri("https://caseapi.allegiancetech.com/CaseManagement.svc/");
                //client.BaseAddress = new Uri("https://caseapiemea.allegiancetech.com/CaseManagement.svc/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var authPayload = new JObject
                {
                    {"userName", userName},
                    {"password", password}
                };

                var response = await client.PostAsJsonAsync("authenticate", authPayload);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.ReasonPhrase);
                    return;
                }

                var authResponse = await response.Content.ReadAsAsync<JObject>();

                var accessToken = authResponse["AuthenticateResult"]["token"];
                var userId = authResponse["AuthenticateResult"]["userId"];

                var caseRequest = new JObject {{"token", accessToken}};

                response = await client.PostAsJsonAsync("getMobileCaseInboxItems", caseRequest);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.ReasonPhrase);
                    return;
                }

                var caseData = await response.Content.ReadAsAsync<JObject>();

                if (caseData != null)
                {
                    var countProperty = caseData["GetMobileCaseInboxItemsResult"]["caseMobileInboxData"]["Rows"];

                    Console.WriteLine($"Total number of cases found: {countProperty}");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
