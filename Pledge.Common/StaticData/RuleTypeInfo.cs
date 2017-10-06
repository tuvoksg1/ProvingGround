using System;
using System.Runtime.Serialization;
using Pledge.Common.Models;

namespace Pledge.Common.StaticData
{
    /// <summary>
    /// Information describing each rule type
    /// </summary>
    [DataContract]
    public class RuleTypeInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RuleTypeInfo" /> class.
        /// </summary>
        /// <param name="data">The data type.</param>
        /// <param name="rule">The rule.</param>
        /// <exception cref="NotSupportedException"></exception>
        public RuleTypeInfo(DataType data, RuleMap rule)
        {
            switch (rule.RuleType)
            {
                case RuleType.None:
                    Description = "Group";
                    break;
                case RuleType.Silent:
                    Description = "Silent";
                    break;
                case RuleType.Equals:
                    Description = "Equals";
                    break;
                case RuleType.NotEqual:
                    Description = "Not Equals";
                    break;
                case RuleType.GreaterThan:
                    Description = data == DataType.Date ? "After" : "Greater Than";
                    break;
                case RuleType.LessThan:
                    Description = data == DataType.Date ? "Before" : "Less Than";
                    break;
                case RuleType.LessThanOrEqualTo:
                    Description = data == DataType.Date ? "Not After" : "Not Greater Than";
                    break;
                case RuleType.GreaterThanOrEqualTo:
                    Description = data == DataType.Date ? "Not Before" : "Not Less Than";
                    break;
                case RuleType.Contains:
                    Description = "Contains";
                    break;
                case RuleType.DoesNotContain:
                    Description = "Does Not Contain";
                    break;
                case RuleType.Year:
                    Description = "Is in the year";
                    break;
                case RuleType.Length:
                    Description = "Length";
                    break;
                case RuleType.Between:
                    Description = "Between";
                    break;
                case RuleType.Match:
                    Description = data == DataType.Text ? "Pattern Match" : "Pattern Match Replace";
                    break;
                case RuleType.NotMatch:
                    Description = "Pattern Does Not Match";
                    break;
                case RuleType.InList:
                    Description = "In List";
                    break;
                case RuleType.NotInList:
                    Description = "Not In List";
                    break;
                case RuleType.InExternalList:
                    Description = "In External List";
                    break;
                case RuleType.NotInExternalList:
                    Description = "Not In External List";
                    break;
                case RuleType.Window:
                    Description = "In Window";
                    break;
                case RuleType.SetText:
                    Description = "Set Text Value";
                    break;
                case RuleType.SetNumber:
                    Description = "Set Number Value";
                    break;
                case RuleType.SetDate:
                    Description = "Set Date Value";
                    break;
                case RuleType.IsOfType:
                    Description = data == DataType.Date ? "Is Date" : "Is Number";
                    break;
                case RuleType.AppendValue:
                    Description = "Append Text";
                    break;
                case RuleType.SetDateFormat:
                    Description = "Set Date Format";
                    break;
                case RuleType.SetDateWindow:
                    Description = "Set Date From Today";
                    break;
                case RuleType.CopyFromCellToCell:
                    Description = "Copy Value";
                    break;
                case RuleType.UpdateDate:
                    Description = "Change Date Value";
                    break;
                case RuleType.SetRandomCharacters:
                    Description = "Set Random Characters";
                    break;
                case RuleType.LookupList:
                    Description = "Look-up";
                    break;
                case RuleType.Substring:
                    Description = "Copy Selected Length";
                    break;
                case RuleType.CalCulateValue:
                    Description = "Calculate";
                    break;
                case RuleType.SplitString:
                    Description = "Copy Split Selection";
                    break;
                default:
                    //this stops any undefined (but valid) rule type being added
                    throw new NotSupportedException();
            }
            RuleType = rule.RuleType;
            EditTemplate = rule.EditTemplate;
            LayoutTemplate = rule.LayoutTemplate;
            EditController = rule.EditController;
            OptionsList = rule.OptionsList;
            ComparatorTypesList = rule.ComparatorTypesList;
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the type of the rule.
        /// </summary>
        /// <value>
        /// The type of the rule.
        /// </value>
        [DataMember]
        public RuleType RuleType { get; set; }

        /// <summary>
        /// Gets or sets the template used to edit the rule parameters.
        /// </summary>
        /// <value>
        /// The rule template.
        /// </value>        
        [DataMember]
        public string EditTemplate { get; set; }

        /// <summary>
        /// Gets or sets the layout template.
        /// </summary>
        /// <value>
        /// The layout template.
        /// </value>
        [DataMember]
        public string LayoutTemplate { get; set; }

        /// <summary>
        /// Gets or sets the Angular controller used to edit the rule parameters.
        /// </summary>
        /// <value>
        /// The rule template.
        /// </value>        
        [DataMember]
        public string EditController { get; set; }

        /// <summary>
        /// Gets or sets the name of the option list.
        /// </summary>
        /// <value>
        /// The name of the option list.
        /// </value>
        [DataMember]
        public string OptionsList { get; set; }

        /// <summary>
        /// Gets or sets the name of the comparator option list.
        /// </summary>
        /// <value>
        /// The name of the comparator option list.
        /// </value>
        [DataMember]
        public string ComparatorTypesList { get; set; }
    }
}
