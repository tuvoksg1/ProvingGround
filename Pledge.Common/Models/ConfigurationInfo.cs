namespace Pledge.Common.Models
{
    /// <summary>
    /// A wrapper class for version-specific configuration xml data
    /// </summary>
    public class ConfigurationInfo : InfoSerializer<ConfigurationInfo>
    {
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public int Version { get; set; }

        /// <summary>
        /// Gets or sets the group id.
        /// </summary>
        /// <value>
        /// The group id.
        /// </value>
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the group name.
        /// </summary>
        /// <value>
        /// The group name.
        /// </value>
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }
    }
}
