using System;
using System.Collections.Generic;
using Pledge.Common.Models;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Represents a single record to be verified/cleaned, such as a row from an input file.
    /// </summary>
    public interface IRecord : IReadOnlyList<Cell>
    {
        /// <summary>
        /// Gets the annotations for this record.
        /// </summary>
        /// <value>
        /// The annotation.
        /// </value>
        string Annotations { get; }

        /// <summary>
        /// Gets the failure codes for this record.
        /// </summary>
        /// <value>
        /// The failure code.
        /// </value>
        string FailureCodes { get; }

        /// <summary>
        /// Gets the highest group failure codes for this record.
        /// </summary>
        /// <value>
        /// The failure code.
        /// </value>
        string GroupFailureCodes { get; }

        /// <summary>
        /// Annotate the record with some disposition messages.
        /// </summary>
        /// <param name="dispositions"></param>
        /// <param name="groupDisposition"></param>
        void Annotate(IEnumerable<IDisposition> dispositions, string groupDisposition);

        /// <summary>
        /// The sequence number for this record in the original source.
        /// </summary>
        int RowNumber { get; }

        /// <summary>
        /// Returns true if the record is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        bool IsValid { get; set; }

        /// <summary>
        /// Gets or sets the batch identifier the record belongs to.
        /// </summary>
        /// <value>
        /// The batch identifier.
        /// </value>
        Guid BatchId { get; }

        /// <summary>
        /// Gets the filename from which the batch was loaded
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Gets the original data batch name from which the batch was loaded
        /// </summary>
        string OriginalBatchName { get; }

        /// <summary>
        /// Gets the state of the record's schema.
        /// </summary>
        /// <value>
        /// The state of the record's schema.
        /// </value>
        RecordSchemaState SchemaState { get; set; }
    }
}