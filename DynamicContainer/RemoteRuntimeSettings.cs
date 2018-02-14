namespace DynamicContainer
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
        /// Gets or sets the lookup service address.
        /// </summary>
        public string LookupServiceAddress { get; set; }
    }
}