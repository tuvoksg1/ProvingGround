using System;
using Web.ServiceReference1;

namespace Web
{
    public class CaseIngestWcf
    {
        public void Start()
        {
            CaseManagementClient client = new CaseManagementClient();

            //userName, password, companyName companyId
            var authResponse = client.Authenticate("sqgabriel@hotmail.com", "Porsche986", "", 10200);

            if (authResponse != null)
            {
                var accessToken = authResponse.token;

                var caseData = client.GetMobileCaseInboxItems(accessToken, null, null, null, false, 0, 50);

                if (caseData != null)
                {
                    Console.WriteLine($"Total number of cases found: {caseData.caseMobileInboxData.TotalNewMessageCount}");
                }
            }
        }
    }
}
