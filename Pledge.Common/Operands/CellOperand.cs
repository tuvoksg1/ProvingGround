using System;
using Pledge.Common.Exceptions;
using Pledge.Common.Interfaces;

namespace Pledge.Common.Operands
{
    /// <summary>
    /// Represents an operand that has a value that varies at runtime.
    /// </summary>
    public class CellOperand : IOperand
    {
        /// <summary>
        /// Constructs a <see cref="CellOperand" /> to read runtime values for the specified cell index
        /// via the given accessor object.
        /// </summary>
        /// <param name="recordAccessor">Accessor object to retrieve cell values</param>
        /// <param name="cellIndex">Index of cell to retrieve</param>
        public CellOperand(RecordAccessor recordAccessor, int cellIndex)
        {
            if (recordAccessor == null)
                throw new PledgeRunException(nameof(recordAccessor), "CellOperand requires a RecordAccessor to be specified");
            CellIndex = cellIndex;
            RecordAccessor = recordAccessor;
        }

        /// <summary>
        /// The current record from which to look up cell values.
        /// </summary>
        private RecordAccessor RecordAccessor { get; }

        private int CellIndex { get; }

        private string CellName => RecordAccessor.ColumnName(CellIndex);

        /// <summary>
        /// Format this operand as a string
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "G";
            switch (format.ToUpperInvariant())
            {
                case "G":
                    return base.ToString();
                case "S":
                    return $"column [{CellName}]";
                case "F":
                    return $"column [{CellName}][value '{TextValue()}']";
                case "V":
                    return $"\"{TextValue()}\"";
                case "N":
                    return $"{TextValue()}";
                default:
                    throw new FormatException($"The '{format}' format string is not supported.");
            }
        }

        /// <summary>
        /// Retrieve the raw text value for the operand.
        /// </summary>
        /// <returns></returns>
        public string TextValue()
        {
            return RecordAccessor.TextValue(CellIndex);
        }

        /// <summary>
        /// Sets the value of the operand.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetValue(string value)
        {
            RecordAccessor.UpdateValue(CellIndex, value);
        }

        /// <summary>
        /// Sets the metadata value of the operand.
        /// </summary>
        /// <param name="metaType">The metadata tag.</param>
        public void SetValueFromMeta(string metaType)
        {
            RecordAccessor.UpdateValueFromMeta(CellIndex, metaType);
        }
    }
}