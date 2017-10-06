using System;
using Pledge.Common.Interfaces;

namespace Pledge.Common.Operands
{
    /// <summary>
    /// Manages a concept of a current record for <see cref="CellOperand" /> objects
    /// to vary what they return on that basis.
    /// </summary>
    public class RecordAccessor
    {
        /// <summary>
        /// The current record from which cell values should be read.
        /// </summary>
        public IRecord Record { get; set; }

        /// <summary>
        /// Gets the value for the specified cell index from the current record.
        /// </summary>
        /// <param name="cellIndex"></param>
        /// <returns></returns>
        public string TextValue(int cellIndex)
        {
            if (Record == null)
                throw new InvalidOperationException(
                    "RecordAccessor cannot retrieve TextValue when there is no current record");
            if (cellIndex >= Record.Count)
                throw new ArgumentOutOfRangeException(nameof(cellIndex),
                    $"RecordAccessor cannot retrieve TextValue for column {cellIndex + 1} from record with {Record.Count} columns");
            return Record[cellIndex].Value ?? ""; // TODO: Consider what NULL behaviour should be
        }

        internal void UpdateValue(int cellIndex, string value)
        {
            if (Record == null)
                throw new InvalidOperationException(
                    "RecordAccessor cannot update Value when there is no current record");
            if (cellIndex >= Record.Count)
                throw new ArgumentOutOfRangeException(nameof(cellIndex),
                    $"RecordAccessor cannot update Value for column {cellIndex + 1} from record with {Record.Count} columns");
            Record[cellIndex].Value = value;
        }

        internal void UpdateValueFromMeta(int cellIndex, string metaType)
        {
            if (Record == null)
                throw new InvalidOperationException(
                    "RecordAccessor cannot update Value when there is no current record");
            if (cellIndex >= Record.Count)
                throw new ArgumentOutOfRangeException(nameof(cellIndex),
                    $"RecordAccessor cannot update Value for column {cellIndex + 1} from record with {Record.Count} columns");

            switch (metaType)
            {
                case "Filename":
                    Record[cellIndex].Value = Record.OriginalBatchName;
                    break;
                case "RowNumber":
                    Record[cellIndex].Value = Record.RowNumber.ToString();
                    break;
            }
        }

        /// <summary>
        /// Get a suitable display name for the given column
        /// </summary>
        /// <param name="cellIndex"></param>
        /// <returns></returns>
        public string ColumnName(int cellIndex)
        {
            if (Record == null) return $"Column_{cellIndex + 1}";
            return Record[cellIndex].ColumnName;
        }
    }
}