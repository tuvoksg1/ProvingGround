using Pledge.Common.Models;
using Pledge.Common.Models.Remote;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Represents all the information needed to construct a remote 
    /// pledge job as well as to run the associated pledge
    /// </summary>
    public interface IJobData
    {
        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        string TenantId { get; set; }
        /// <summary>
        /// Gets or sets the tenant code.
        /// </summary>
        string TenantCode { get; set; }
        /// <summary>
        /// Gets or sets the remote job configuration.
        /// </summary>
        RemoteJob Job { get; set; }
        /// <summary>
        /// Gets or sets the pledge configuration.
        /// </summary>
        BaseConfiguration PledgeConfiguration { get; set; }
    }
}
