namespace Pledge.Common.Models.Automation
{
    /// <summary>
    /// A model of the VisualCron Connection
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the connection type.
        /// </summary>
        public ConnectionType Type { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
    }
}