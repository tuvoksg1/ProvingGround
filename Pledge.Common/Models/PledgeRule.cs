using System;
using System.Collections.Generic;

namespace Pledge.Common.Models
{
    /// <summary>
    /// defines the properties of a rule to apply to the input file
    /// </summary>
    public class PledgeRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PledgeRule"/> class.
        /// </summary>
        public PledgeRule()
        {
            RuleId = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the type of the data.
        /// </summary>
        /// <value>
        /// The type of the data.
        /// </value>
        public DataType DataType { get; set; }
        /// <summary>
        /// Gets or sets the type of the rule.
        /// </summary>
        /// <value>
        /// The type of the rule.
        /// </value>
        public RuleType RuleType { get; set; }
        /// <summary>
        /// Gets or sets the operands.
        /// </summary>
        /// <value>
        /// The operands.
        /// </value>
        public List<Operand> Operands { get; set; }
        /// <summary>
        /// Gets or sets the rule identifier.
        /// </summary>
        /// <value>
        /// The rule identifier.
        /// </value>
        public Guid RuleId { get; set; }
        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        public List<PledgeRule> Children { get; set; }
        /// <summary>
        /// Gets or sets the conjunction logic applied to the rule's result.
        /// </summary>
        /// <value>
        /// The type of the logic.
        /// </value>
        public LogicType LogicType { get; set; }
        /// <summary>
        /// Gets or sets the evaluation mode.
        /// </summary>
        /// <value>
        /// The mode.
        /// </value>
        public EvaluationMode Mode { get; set; }
        /// <summary>
        /// Gets or sets a the failure code
        /// </summary>
        /// <value>
        /// The failure code.
        /// </value>
        public string FailureCode { get; set; }
    }
}
