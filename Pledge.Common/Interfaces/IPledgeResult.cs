using System;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// The overall result of a pledge run
    /// </summary>
    public interface IPledgeResult
    {
        /// <summary>
        /// Gets a value of total number of records processed.
        /// </summary>
        int TotalRecordsProcessed { get; set; }

        /// <summary>
        /// Gets a value indicating whether [file has invalid records].
        /// </summary>
        /// <value>
        /// <c>true</c> if file has invalid records; otherwise, <c>false</c>.
        /// </value>
        bool FileHasInvalidRecords { get; set; }

        /// <summary>
        /// Gets a value indicating whether file has valid records.
        /// </summary>
        /// <value>
        /// <c>true</c> if file has valid records; otherwise, <c>false</c>.
        /// </value>
        bool FileHasValidRecords { get; set; }

        /// <summary>
        /// Gets the egest component.
        /// </summary>
        /// <value>
        /// The egest component.
        /// </value>
        IPipelineMember EgestComponent { get; }

        /// <summary>
        /// Gets the count to passed rows.
        /// </summary>
        int TotalPassedRecordsCount { get; set; }

        /// <summary>
        /// Gets the count to failed rows.
        /// </summary>
        int TotalFailedRecordsCount { get; set; }

        /// <summary>
        /// Gets or sets the name of the input file.
        /// </summary>
        string InputFileName { get; set; }

        /// <summary>
        /// Gets or sets the exception that was handled during processing.
        /// </summary>
        Exception HandledException { get; set; }
    }
}
