using System.Collections.Generic;
using Pledge.Common.Models;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Document interface 
    /// </summary>
    public interface IDocument
    {
        /// <summary>
        /// Gets the schema that defines the makeup of the input document in this configuration.
        /// </summary>
        /// <value>
        /// The schema.
        /// </value>
        List<Definition> InputSchema { get; set; }
        /// <summary>
        /// Gets the schema that defines the makeup of the output document in this configuration.
        /// </summary>
        /// <value>
        /// The schema.
        /// </value>
        List<OutputDefinition> OutputSchema { get; set; }
        /// <summary>
        /// The file Delimiter
        /// </summary>
        string InputDelimiter { get; set; }
        /// <summary>
        /// Document type such as CSVs, Fixed Width etc
        /// </summary>
        DocumentType InputType { get; set; }
        /// <summary>
        /// Flag to indicate if the first line is a header
        /// </summary>
        bool InputHasHeader { get; set; }
        /// <summary>
        /// The text qualifier
        /// </summary>
        string InputTextQualifier { get; set; }
        /// <summary>
        /// The file Delimiter
        /// </summary>
        string OutputDelimiter { get; set; }
        /// <summary>
        /// Document type such as CSVs, Fixed Width etc
        /// </summary>
        DocumentType OutputType { get; set; }
        /// <summary>
        /// Flag to indicate if the first line is a header
        /// </summary>
        bool OutputHasHeader { get; set; }
        /// <summary>
        /// The text qualifier
        /// </summary>
        string OutputTextQualifier { get; set; }
        /// <summary>
        /// Gets or sets the virtual column offset.
        /// </summary>
        /// <value>
        /// The virtual offset.
        /// </value>
        int VirtualColumnOffset { get; set; }

        /// <summary>
        /// Property to hold configuration options
        /// </summary>
        ConfigurationOptions Options { get; set; }
    }
}
