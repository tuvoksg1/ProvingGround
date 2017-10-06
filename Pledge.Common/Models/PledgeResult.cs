using System;
using Pledge.Common.Interfaces;

namespace Pledge.Common.Models
{
    /// <summary>
    /// The overall result of a pledge run
    /// </summary>
    /// <seealso cref="IPledgeResult" />
    public class PledgeResult : IPledgeResult
    {
        /// <summary>
        /// Gets a value of total number of records processed.
        /// </summary>
        public int TotalRecordsProcessed { get; set; }

        /// <summary>
        /// Gets a value indicating whether [file has invalid records].
        /// </summary>
        /// <value>
        /// <c>true</c> if [file has invalid records]; otherwise, <c>false</c>.
        /// </value>
        public bool FileHasInvalidRecords { get; set; }

        /// <summary>
        /// Gets a value indicating whether [file has valid records].
        /// </summary>
        /// <value>
        /// <c>true</c> if [file has valid records]; otherwise, <c>false</c>.
        /// </value>
        public bool FileHasValidRecords { get; set; }

        /// <summary>
        /// Gets the egest component.
        /// </summary>
        /// <value>
        /// The egest component.
        /// </value>
        public IPipelineMember EgestComponent { get; set; }

        /// <summary>
        /// Gets the count to passed rows.
        /// </summary>
        public int TotalPassedRecordsCount { get; set; }

        /// <summary>
        /// Gets the count to failed rows.
        /// </summary>
        public int TotalFailedRecordsCount { get; set; }

        /// <summary>
        /// Gets or sets the name of the input file.
        /// </summary>
        public string InputFileName { get; set; }

        /// <summary>
        /// Gets or sets the exception that was handled during processing.
        /// </summary>
        public Exception HandledException { get; set; }
    }
}
