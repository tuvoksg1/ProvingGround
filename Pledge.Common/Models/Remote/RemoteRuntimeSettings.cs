namespace Pledge.Common.Models.Remote
{
    /// <summary>
    /// The settings for a remote pledge runtime
    /// </summary>
    public class RemoteRuntimeSettings
    {
        /// <summary>
        /// Gets or sets the pledge API address.
        /// </summary>
        public string PledgeApiAddress { get; set; }
        /// <summary>
        /// Gets or sets the external list provider.
        /// </summary>
        public string ExternalListProvider { get; set; }
        /// <summary>
        /// Gets or sets the passport server URL.
        /// </summary>
        public string PassportServerUrl { get; set; }
        /// <summary>
        /// Gets or sets the pledge API scope.
        /// </summary>
        public string PledgeApiScope { get; set; }
        /// <summary>
        /// Gets or sets the pledge job scope.
        /// </summary>
        public string PledgeJobClient { get; set; }
        /// <summary>
        /// Gets or sets the pledge job secret.
        /// </summary>
        public string PledgeJobSecret { get; set; }
        /// <summary>
        /// Gets or sets the external list service address.
        /// </summary>
        public string ExternalListServiceAddress { get; set; }
        /// <summary>
        /// Gets or sets the audit service address.
        /// </summary>
        public string AuditServiceAddress { get; set; }
        /// <summary>
        /// Gets or sets the index of the audit service.
        /// </summary>
        public string AuditServiceIndex { get; set; }
        /// <summary>
        /// Gets or sets the audit service user filter.
        /// </summary>
        public string AuditServiceUserFilter { get; set; }
        /// <summary>
        /// Gets or sets the audit service group filter.
        /// </summary>
        public string AuditServiceGroupFilter { get; set; }
    }
}