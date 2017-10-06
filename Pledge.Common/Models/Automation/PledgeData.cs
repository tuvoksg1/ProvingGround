using System.IO;
using Pledge.Common.Interfaces;

namespace Pledge.Common.Models.Automation
{
    /// <summary>
    /// Pledge data used for calls within VC
    /// </summary>
    public class PledgeData
    {
        /// <summary>
        /// Tenant Id
        /// </summary>
        public string TenantId { get; set; }
        /// <summary>
        /// Gets or sets the tenant code.
        /// </summary>
        public string TenantCode { get; set; }
        /// <summary>
        /// Gets or sets the user Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Pledge manager used for calls within VC
        /// </summary>
        public IPledgeManager PledgeManager { get; set; }
        /// <summary>
        /// Gets or sets the workspace path.
        /// </summary>
        public string WorkspacePath { get; set; }
        /// <summary>
        /// Gets or sets the workspace teardown identifier.
        /// </summary>
        public string WorkspaceTeardownId { get; set; }
        /// <summary>
        /// Gets or sets the path to the local copy of the pledge executable.
        /// </summary>
        public string PledgeExecutable { get; set; }
        /// <summary>
        /// Gets or sets the path to the base copy of the pledge executable.
        /// </summary>
        public string PledgeExecutableSource { get; set; }
        /// <summary>
        /// Gets the pledge executable target.
        /// </summary>
        public string PledgeExecutableTarget => Path.GetDirectoryName(PledgeExecutable);
    }
}
