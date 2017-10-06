using System.Collections.Generic;
using Pledge.Common.Interfaces;
using Pledge.Common.Models;

namespace Pledge.Common
{
    /// <summary>
    /// Base document class with all the information needed for the document
    /// </summary>
    public class BaseDocument : IDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDocument"/> class.
        /// </summary>
        public BaseDocument()
        {
            Options = new ConfigurationOptions
            {
                OutputAllRecords = true,
                OutputErrorCode = true,
                OutputErrorDescription = true,
                OutputGroupErrorCode = true,
                UseInputSettingsForErrors = true
            };
        }

        /// <summary>
        /// Schema which is a list of column definitions
        /// </summary>
        public List<Definition> InputSchema { get; set; }
        /// <summary>
        /// Schema which is a list of column definitions
        /// </summary>
        public List<OutputDefinition> OutputSchema { get; set; }
        /// <summary>
        /// The file Delimiter
        /// </summary>
        public string InputDelimiter { get; set; }
        /// <summary>
        /// Document type such as CSVs, Fixed Width etc
        /// </summary>
        public DocumentType InputType { get; set; }
        /// <summary>
        /// Flag to indicate if the first line is a header
        /// </summary>
        public bool InputHasHeader { get; set; }
        /// <summary>
        /// The text qualifier
        /// </summary>
        public string InputTextQualifier { get; set; }
        /// <summary>
        /// The file Delimiter
        /// </summary>
        public string OutputDelimiter { get; set; }
        /// <summary>
        /// Document type such as CSVs, Fixed Width etc
        /// </summary>
        public DocumentType OutputType { get; set; }
        /// <summary>
        /// Flag to indicate if the first line is a header
        /// </summary>
        public bool OutputHasHeader { get; set; }
        /// <summary>
        /// The text qualifier
        /// </summary>
        public string OutputTextQualifier { get; set; }
        /// <summary>
        /// Gets or sets the virtual column offset.
        /// </summary>
        /// <value>
        /// The virtual offset.
        /// </value>
        public int VirtualColumnOffset { get; set; }

        /// <summary>
        /// Property to store the options for this configuration
        /// </summary>
        public ConfigurationOptions Options { get; set; }
    }
}
