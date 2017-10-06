using System.Collections.Generic;
using Pledge.Common.Interfaces;

namespace Pledge.Common.Models.Remote
{
    /// <summary>
    /// Arguments for members of a pipeline
    /// </summary>
    public class PipelineArgument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PipelineArgument"/> class.
        /// </summary>
        public PipelineArgument(IReadOnlyDictionary<string, string> propertyBag, IDocument document, IRuleSet rules, 
            IPipelineMember successor, IAuditor auditor)
        {
            PropertyBag = propertyBag;
            Document = document;
            Rules = rules;
            Successor = successor;
            Auditor = auditor;
        }

        /// <summary>
        /// Gets the property bag.
        /// </summary>
        /// <value>
        /// The property bag.
        /// </value>
        public IReadOnlyDictionary<string, string> PropertyBag { get; }

        /// <summary>
        /// Gets the document.
        /// </summary>
        /// <value>
        /// The document.
        /// </value>
        public IDocument Document { get; }

        /// <summary>
        /// Gets the rules.
        /// </summary>
        /// <value>
        /// The rules.
        /// </value>
        public IRuleSet Rules { get; }

        /// <summary>
        /// Gets the pipeline successor.
        /// </summary>
        /// <value>
        /// The pipeline successor.
        /// </value>
        public IPipelineMember Successor { get; }

        /// <summary>
        /// Gets or sets the auditor.
        /// </summary>
        public IAuditor Auditor { get; set; }
    }
}
