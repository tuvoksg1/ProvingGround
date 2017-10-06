using System;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Abstraction of ability to retrieve the value for an operand.
    /// </summary>
    public interface IOperand : IFormattable
    {
        /// <summary>
        /// Retrieve the raw text value for the operand.
        /// </summary>
        string TextValue();

        /// <summary>
        /// Sets the value of the operand.
        /// </summary>
        /// <param name="value">The value.</param>
        void SetValue(string value);

        /// <summary>
        /// Sets the value of the operand.
        /// </summary>
        /// <param name="metaType">The value.</param>
        void SetValueFromMeta(string metaType);
    }
}