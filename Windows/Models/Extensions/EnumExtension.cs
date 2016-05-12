using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Windows.Models.Extensions
{
    public static class EnumExtension
    {
        public static string Description(this Enum enumeration)
        {
            var type = enumeration.GetType();

            var memInfo = type.GetMember(enumeration.ToString());

            if (memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return enumeration.ToString();
        }
    }
}
