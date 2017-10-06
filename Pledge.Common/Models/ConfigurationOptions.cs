namespace Pledge.Common.Models
{
    /// <summary>
    /// Configuration Options
    /// </summary>
    public class ConfigurationOptions
    {
        /// <summary>
        /// Output All Records
        /// </summary>
        public bool OutputAllRecords { get; set; }

        /// <summary>
        /// Output error code property
        /// </summary>
        public bool OutputErrorCode { get; set; }

        /// <summary>
        /// Output error code description
        /// </summary>
        public bool OutputErrorDescription { get; set; }

        /// <summary>
        /// Output group error code property
        /// </summary>
        public bool OutputGroupErrorCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use the input settings to process all matched rows.
        /// </summary>
        /// <value>
        /// <c> true</c> Process all rows matched (set as default); else<c>false</c>.
        /// </value>
        public bool ProcessAllMatchedRows { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use the input settings for errors.
        /// </summary>
        /// <value>
        /// <c>true</c> to use input settings for errors; otherwise, <c>false</c>.
        /// </value>
        public bool UseInputSettingsForErrors { get; set; }
    }
}
