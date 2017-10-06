using Pledge.Common.Interfaces;

namespace Pledge.Common.Models.Remote
{
    /// <summary>
    /// 
    /// </summary>
    public class JobData : IJobData
    {
        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        public string TenantId { get; set; }
        /// <summary>
        /// Gets or sets the tenant code.
        /// </summary>
        public string TenantCode { get; set; }
        /// <summary>
        /// Gets or sets the remote job configuration.
        /// </summary>
        public RemoteJob Job { get; set; }
        /// <summary>
        /// Gets or sets the pledge configuration.
        /// </summary>
        public BaseConfiguration PledgeConfiguration { get; set; }
    }
}
