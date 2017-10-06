using System;
using Pledge.Common.Interfaces;
using Pledge.Common.Operands;

namespace Pledge.Common.Extensions
{
    /// <summary>
    /// Extension methods for the IOperand interface
    /// </summary>
    public static class OperandExtension
    {
        /// <summary>
        /// Convert the operand's raw text value to a Decimal
        /// </summary>
        /// <param name="thisOperand">The operand</param>
        /// <returns>The decimal value of the operand.</returns>
        public static decimal NumericValue(this IOperand thisOperand)
        {
            return Convert.ToDecimal(thisOperand.TextValue());
        }

        /// <summary>
        /// Converts the operand's raw text value to a DateTime
        /// </summary>
        /// <param name="thisOperand">The operand</param>
        /// <returns>The DateTime value of the operand.</returns>
        public static DateTime DateTimeValue(this IOperand thisOperand)
        {
            return Convert.ToDateTime(thisOperand.TextValue());
        }

        /// <summary>
        /// Converts the operand's raw text value to a DateTime using the specified format 
        /// </summary>
        /// <param name="thisOperand">The this operand.</param>
        /// <param name="format">The expected date format string of the operand.</param>
        /// <returns>The DateTime value of the operand</returns>
        public static DateTime DateTimeValue(this IOperand thisOperand, string format)
        {
            return DateTime.ParseExact(thisOperand.TextValue(), format, System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the operand's raw text value to a DateTime using the specified format 
        /// </summary>
        /// <param name="thisOperand">The this operand.</param>
        /// <param name="format">The expected date format object of the operand.</param>
        /// <returns>The DateTime value of the operand</returns>
        public static DateTime DateTimeValue(this IOperand thisOperand, IOperand format)
        {
            if (thisOperand is CellOperand)
                return DateTime.ParseExact(thisOperand.TextValue(), format.TextValue(), System.Globalization.CultureInfo.InvariantCulture);

            return DateTimeValue(thisOperand);
        }

        /// <summary>
        /// Convert the operand's raw text value to a 32-bit Integer
        /// </summary>
        /// <param name="thisOperand">The operand</param>
        /// <returns>The integral value of the operand.</returns>
        public static int IntegralValue(this IOperand thisOperand)
        {
            return Convert.ToInt32(thisOperand.TextValue());
        }

        /// <summary>
        /// Determines whether the instance is writeable.
        /// </summary>
        /// <param name="thisOperand">The operand.</param>
        /// <returns>True if the operand is writaeable, else false</returns>
        public static bool IsWriteable(this IOperand thisOperand)
        {
            return thisOperand is CellOperand;
        }

        /// <summary>
        /// Converts the operand's raw text value to a formatted DateTime using the specified format
        /// </summary>
        /// <param name="thisOperand">The this operand.</param>
        /// <param name="format">The expected date format string of the operand.</param>
        /// <returns>The DateTime value of the operand</returns>
        public static string FormattedDateTimeValue(this IOperand thisOperand, string format)
        {
            if (thisOperand is CellOperand)
                return thisOperand.TextValue();

            return Convert.ToDateTime(thisOperand.TextValue()).ToString(format);
        }
    }
}
