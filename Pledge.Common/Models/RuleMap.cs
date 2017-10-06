namespace Pledge.Common.Models
{
    /// <summary>
    /// Represents the mapping of a rule type to a data type and the info for creating the rule that can be executed
    /// </summary>
    public class RuleMap
    {
        /// <summary>
        /// Gets or sets the type of the rule.
        /// </summary>
        /// <value>
        /// The type of the rule.
        /// </value>
        public RuleType RuleType { get; set; }

        /// <summary>
        /// Gets or sets the information needed to construct the rule.
        /// </summary>
        /// <value>
        /// The rule information.
        /// </value>
        public string RuleInfo { get; set; }

        /// <summary>
        /// Gets or sets the template used to edit the rule parameters.
        /// </summary>
        /// <value>
        /// The rule template.
        /// </value>
        public string EditTemplate { get; set; }

        /// <summary>
        /// Gets or sets the layout template.
        /// </summary>
        /// <value>
        /// The layout template.
        /// </value>
        public string LayoutTemplate { get; set; }

        /// <summary>
        /// Gets or sets the Angular controller used to edit the rule parameters.
        /// </summary>
        /// <value>
        /// The rule controller.
        /// </value>
        public string EditController { get; set; }

        /// <summary>
        /// Gets or sets the name of the option list.
        /// </summary>
        /// <value>
        /// The name of the option list.
        /// </value>
        public string OptionsList { get; set; }

        /// <summary>
        /// Gets or sets the name of the comparator option list.
        /// </summary>
        /// <value>
        /// The name of the comparator option list.
        /// </value>
        public string ComparatorTypesList { get; set; }
    }
}
