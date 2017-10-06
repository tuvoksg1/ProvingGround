using System.Collections.Generic;

namespace Pledge.Common.Models
{
    /// <summary>
    /// A mapping od data types to rules
    /// </summary>
    public class DataMap
    {
        /// <summary>
        /// Gets or sets the type of the data.
        /// </summary>
        /// <value>
        /// The type of the data.
        /// </value>
        public DataType DataType { get; set; }

        /// <summary>
        /// Gets or sets the rules for this data type.
        /// </summary>
        /// <value>
        /// The mappings.
        /// </value>
        public List<RuleMap> RuleMaps { get; set; }
    }
}
