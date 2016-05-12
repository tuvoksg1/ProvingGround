using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows.Models.Extensions
{
    public class EnumInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumInfo"/> class.
        /// </summary>
        public EnumInfo(Enum enumeration)
        {
            var code = Convert.ChangeType(enumeration, enumeration.GetTypeCode());

            Value = code != null ? (int)code : -1;
            Label = enumeration.Description();
        }

        public static IEnumerable<EnumInfo> ParseEnum<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");

            var optionInfo = new List<EnumInfo>();

            foreach (T item in Enum.GetValues(typeof(T)))
            {
                optionInfo.Add(new EnumInfo(item as Enum));
            }

            return optionInfo;
        }

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
