namespace Pledge.Common.Models.Remote
{
    /// <summary>
    /// The settings for a local pledge runtime
    /// </summary>
    public class LocalRuntimeSettings
    {
        /// <summary>
        /// Gets or sets the scheduled job directory.
        /// </summary>
        public string ScheduledJobDirectory { get; set; }
        /// <summary>
        /// Gets or sets the scheduled job extension.
        /// </summary>
        public string ScheduledJobExtension { get; set; }
        /// <summary>
        /// Gets or sets the configuration directory.
        /// </summary>
        public string ConfigurationDirectory { get; set; }
        /// <summary>
        /// Gets or sets the configuration extension.
        /// </summary>
        public string ConfigurationExtension { get; set; }
        /// <summary>
        /// Gets or sets the audit log directory.
        /// </summary>
        public string AuditLogDirectory { get; set; }
        /// <summary>
        /// Gets or sets the name of the audit log file.
        /// </summary>
        public string AuditLogFileName { get; set; }
        /// <summary>
        /// Gets or sets the external list provider.
        /// </summary>
        public string ExternalListProvider { get; set; }
        /// <summary>
        /// Gets or sets the list directory.
        /// </summary>
        public string ListDirectory { get; set; }
        /// <summary>
        /// Gets or sets the list extension.
        /// </summary>
        public string ListExtension { get; set; }
        /// <summary>
        /// Gets or sets the list metadata extension.
        /// </summary>
        public string ListMetaDataExtension { get; set; }
        
    }
}