using System;
using System.ComponentModel;
using System.Linq;

namespace Pledge.Common.Extensions
{
    /// <summary>
    /// Extension on the Enum type
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Gets the description for the enumeration.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns>The description attribute value</returns>
        public static string GetDescription(this Enum enumeration)
        {
            var type = enumeration.GetType();

            var memInfo = type.GetMember(enumeration.ToString());

            if (memInfo.Length <= 0) return enumeration.ToString();

            var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attrs.Length > 0)
            {
                return ((DescriptionAttribute)attrs[0]).Description;
            }

            return enumeration.ToString();
        }

        /// <summary>
        /// Gets the integral value of the enumeration.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns>The integral value of the enumeration</returns>
        public static int GetValue(this Enum enumeration)
        {
            var code = Convert.ChangeType(enumeration, enumeration.GetTypeCode());

            if (code == null)
            {
                return int.MinValue;
            }

            return (int)code;
        }

        /// <summary>
        /// Get the type of Enum from the description.
        /// </summary>
        /// <param name="description"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static T GetEnumValueFromDescription<T>(this string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();
            var fields = type.GetFields();
            var field = fields
                            .SelectMany(f => f.GetCustomAttributes(
                                typeof(DescriptionAttribute), false), (
                                    f, a) => new { Field = f, Att = a }).SingleOrDefault(a => ((DescriptionAttribute)a.Att)
                                .Description == description);
            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }

        /// <summary>
        /// Gets the enum value from its numeric value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static T GetEnumValueFromNumericValue<T>(this int value)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();

            if (type.IsEnumDefined(value))
            {
                return (T)Enum.ToObject(type, value);
            }

            return default(T);
        }
    }
}
