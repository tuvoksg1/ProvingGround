using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Pledge.Common.Models;

namespace Pledge.Common.StaticData
{
    /// <summary>
    /// A wrapper class for data types that provides a user friendly display description
    /// </summary>
    [DataContract]
    public class DataTypeInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataTypeInfo" /> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="rules">The rules.</param>
        /// <exception cref="NotSupportedException"></exception>
        public DataTypeInfo(DataType type, IEnumerable<RuleMap> rules)
        {
            switch (type)
            {
                case DataType.Text:
                    Description = "Text";
                    break;
                case DataType.Number:
                    Description = "Number";
                    break;
                case DataType.Date:
                    Description = "Date";
                    break;
                case DataType.Group:
                    Description = "Group";
                    break;
                case DataType.Transform:
                    Description = "Transform";
                    break;
                default:
                    //this stops any undefined data type being added
                    throw new NotSupportedException();
            }

            DataType = type;
            RuleTypes =
                rules.Select(
                    arg =>
                        new RuleTypeInfo(type, arg))
                    .ToList();
        }

        /// <summary>
        /// Data type enum. WholeNumber,DecimalNumber,Text or Date
        /// </summary>
        [DataMember]
        public DataType DataType { get; set; }

        /// <summary>
        /// Display-friendly desciption of the data type
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the rule types.
        /// </summary>
        /// <value>
        /// The rule types.
        /// </value>
        [DataMember]
        public List<RuleTypeInfo> RuleTypes { get; set; }
    }
}
