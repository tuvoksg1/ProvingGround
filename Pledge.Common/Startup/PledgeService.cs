using System.Configuration;
using Pledge.Common.Models;

namespace Pledge.Common.Startup
{
    /// <summary>
    /// A Pledge self-hosted service
    /// </summary>
    public class PledgeService
    {
        private PledgeService(string webApiAddress, string serviceAddress)
        {
            WebApiAddress = webApiAddress;
            ServiceAddress = serviceAddress;
        }

        /// <summary>
        /// Gets or sets the web API address.
        /// </summary>
        /// <value>
        /// The web API address.
        /// </value>
        public string WebApiAddress { get; }
        /// <summary>
        /// Gets or sets the service address.
        /// </summary>
        /// <value>
        /// The service address.
        /// </value>
        public string ServiceAddress { get; }

        /// <summary>
        /// Fetches the configured information for this pledge service.
        /// </summary>
        /// <returns></returns>
        public static PledgeService Fetch()
        {
            return new PledgeService(GetApiAddress(), GetServiceAddress());
        }

        private static string GetApiAddress()
        {
            var serverUrl = ConfigurationManager.AppSettings[PledgeGlobal.PledgeWebApiAddress];
            return serverUrl;
        }

        private static string GetServiceAddress()
        {
            var clientUrl = ConfigurationManager.AppSettings[PledgeGlobal.PledgeServiceAddress];
            return clientUrl;
        }
    }
}
