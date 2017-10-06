using System.Collections.Generic;
using Pledge.Common.Interfaces;

namespace Pledge.Common.Models.Remote
{
    /// <summary>
    /// The callback payload for a pipeline
    /// </summary>
    public class PipelinePayload
    {
        /// <summary>
        /// Gets or sets the ingest settings.
        /// </summary>
        /// <value>
        /// The ingest settings.
        /// </value>
        public SerializableDictionary<string, string> IngestSettings { get; set; }

        /// <summary>
        /// Gets or sets the Egest settings.
        /// </summary>
        /// <value>
        /// The Egest settings.
        /// </value>
        public SerializableDictionary<string, string> EgestSettings { get; set; }

        /// <summary>
        /// Gets or sets the pledge result.
        /// </summary>
        /// <value>
        /// The pledge result.
        /// </value>
        public IEnumerable<IPledgeResult> PledgeResults { get; set; }
    }
}
