namespace Pledge.Common.Models.Remote
{
    /// <summary>
    /// A pre-configured property for a job handler
    /// </summary>
    public class Property
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public string Label { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this property is required.
        /// </summary>
        /// <value>
        /// <c>true</c> if this property is required; otherwise, <c>false</c>.
        /// </value>
        public bool IsRequired { get; set; }
    }
}
