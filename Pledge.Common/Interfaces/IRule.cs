using System;
using System.Collections.Generic;
using Pledge.Common.Models;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Rule interface
    /// </summary>
    public interface IRule
    {
        /// <summary>
        /// Gets the rule identifier.
        /// </summary>
        /// <value>
        /// The rule identifier.
        /// </value>
        Guid Id { get; }

        /// <summary>
        /// Gets the rule data type.
        /// </summary>
        /// <value>
        /// The data type of the rule.
        /// </value>
        DataType DataType { get; }

        /// <summary>
        /// Gets the rule description.
        /// </summary>
        /// <value>
        /// The description of the rule.
        /// </value>
        string Description { get; }

        /// <summary>
        /// Gets the conjunction logic applied to the rule's result.
        /// </summary>
        /// <value>
        /// The type of the logic.
        /// </value>
        LogicType LogicType { get; }

        /// <summary>
        /// Gets the evaluation mode for this rule.
        /// </summary>
        /// <value>
        /// The evaluation mode.
        /// </value>
        EvaluationMode Mode { get; }

        /// <summary>
        /// Gets the child rules.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        IReadOnlyList<IRule> Children { get; }

        /// <summary>
        /// Gets the failure code for the rule.
        /// </summary>
        /// <value>
        /// The failure code.
        /// </value>
        string FailureCode { get; }

        /// <summary>
        /// Executes the rule against specified input.
        /// </summary>
        /// <returns>
        /// The result of the rule execution
        /// </returns>
        IResult Execute();
    }
}