using System;
using Pledge.Common.Interfaces;

namespace Pledge.Common.Operands
{
    /// <summary>
    /// Represents an operand that has a constant value defined within the configuration.
    /// </summary>
    public class ConstantOperand : IOperand
    {
        /// <summary>
        /// Constructs a <see cref="ConstantOperand" /> with the specified constant value.
        /// </summary>
        /// <param name="value"></param>
        public ConstantOperand(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "ConstantOperand initialized with null value");
            Value = value;
        }

        private string Value { get; }

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
                case "F":
                    return $"the required value ['{Value}']";
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
        public string TextValue() => Value;

        /// <summary>
        /// Sets the value of the operand.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void SetValue(string value)
        {
            throw new InvalidOperationException("The value of a constant operand cannot be updated");
        }

        /// <summary>
        /// Sets the metadata value of the operand.
        /// </summary>
        /// <param name="metaType">The metadata tag.</param>
        public void SetValueFromMeta(string metaType)
        {
            throw new InvalidOperationException("The value of a constant operand cannot be updated");
        }
    }
}