using System;
using System.Collections.Generic;
using System.Linq;
using Pledge.Common.Extensions;

namespace Pledge.Common.StaticData
{
    /// <summary>
    /// Creates a UI-friendly wrapper for static dialog options
    /// </summary>
    public class DialogOptionInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogOptionInfo"/> class.
        /// </summary>
        public DialogOptionInfo(Enum enumeration)
        {
            Name = enumeration.ToString();
            Value = enumeration.GetValue();
            Label = enumeration.GetDescription();
        }

        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <typeparam name="T">The Enum type for which the option list should be created</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentException">argument must be an enumerated type</exception>
        public static List<DialogOptionInfo> GetOptions<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("argument must be an enumerated type");

            return (from T item in Enum.GetValues(typeof (T)) select new DialogOptionInfo(item as Enum)).ToList();
        }

        /// <summary>
        /// The textual value of the enumeration
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The numeric value of the enumeration
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Display-friendly desciption of the enumeration
        /// </summary>
        public string Label { get; set; }
    }
}
