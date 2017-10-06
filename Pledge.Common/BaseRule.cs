using System;
using System.Collections.Generic;
using System.Text;
using Pledge.Common.Interfaces;
using Pledge.Common.Models;

namespace Pledge.Common
{
    /// <summary>
    /// The base rule class which implements the rule interface template
    /// </summary>
    public abstract class BaseRule : IRule
    {

        /// <summary>
        /// Base constructor for rules.
        /// </summary>
        /// <param name="ruleArguments"></param>
        protected BaseRule(RuleArguments ruleArguments)
        {
            Id = ruleArguments.RuleId;
            DataType = ruleArguments.DataType;
            Description = ruleArguments.Description;
            Operands = ruleArguments.Operands;
            Children = ruleArguments.ChildRules;
            LogicType = ruleArguments.LogicType;
            Mode = ruleArguments.Mode;
            FailureCode = ruleArguments.FailureCode;
        }

        /// <summary>
        /// Gets the rule identifier.
        /// </summary>
        /// <value>
        /// The rule identifier.
        /// </value>
        public Guid Id { get; }

        /// <summary>
        /// Gets the rules type.
        /// </summary>
        /// <value>
        /// The rule type.
        /// </value>
        public DataType DataType { get; }

        /// <summary>
        /// Gets the rules description.
        /// </summary>
        /// <value>
        /// The rule description.
        /// </value>
        public string Description { get; }

        /// <summary>
        /// The operands for this rule
        /// </summary>
        protected IReadOnlyList<IOperand> Operands { get; }

        /// <summary>
        /// Gets or sets the conjunction logic applied to the rule's result.
        /// </summary>
        /// <value>
        /// The type of the logic.
        /// </value>
        public LogicType LogicType { get; }

        /// <summary>
        /// Gets the evaluation mode for this rule.
        /// </summary>
        /// <value>
        /// The evaluation mode.
        /// </value>
        public EvaluationMode Mode { get; }

        /// <summary>
        /// Gets the child rules.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        public IReadOnlyList<IRule> Children { get; }

        /// <summary>
        /// Gets the failure code for the rule.
        /// </summary>
        /// <value>
        /// The failure code.
        /// </value>
        public string FailureCode { get; }

        /// <summary>
        /// Virtual definition/implementation of overloaded Execute method
        /// </summary>
        /// <returns>
        /// The result of the rule execution
        /// </returns>
        public IResult Execute()
        {
            try
            {
                return ExecuteRule();
            }
            catch (Exception error)
            {
                return ExceptionOutcome(error);
            }
        }

        /// <summary>
        /// Executes the rule.
        /// </summary>
        /// <returns></returns>
        protected abstract IResult ExecuteRule();

        /// <summary>
        /// Returns either a passed or failed outcome based on the specified result
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected Result BooleanOutcome(bool result)
        {
            if (result)
                return new Result(ResultType.Passed);

            var disposition = new Disposition { Annotation = $"{this} - FAILED", FailureCode = FailureCode };
            return new Result(ResultType.Failed, disposition);
        }

        /// <summary>
        /// Creates an outcome for a rule that throws an exception.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <returns>
        /// The outcome
        /// </returns>
        private Result ExceptionOutcome(Exception error)
        {
            var builder = new StringBuilder();
            while (error != null)
            {
                builder.AppendLine(error.Message);
                error = error.InnerException;
            }

            var disposition = new Disposition {Annotation = $"{this} - ERROR (Type Mismatch)", FailureCode = FailureCode};
            return new Result(ResultType.Exception, disposition, builder.ToString());
        }

        /// <summary>
        /// Between exclusive of the upper and bound values. So 5 to 10 will return 6,7,8,9
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparator0"></param>
        /// <param name="comparator1"></param>
        /// <returns></returns>
        protected bool BetweenExclusive(IComparable value, IComparable comparator0, IComparable comparator1)
        {
            return value.CompareTo(comparator0) > 0 && value.CompareTo(comparator1) < 0;
        }

        /// <summary>
        /// Between inclusive of the upper and lower bound values. So 5 to 10 will return 5,6,7,8,9,10
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparator0"></param>
        /// <param name="comparator1"></param>
        /// <returns></returns>
        protected bool BetweenInclusive(IComparable value, IComparable comparator0, IComparable comparator1)
        {
            return value.CompareTo(comparator0) >= 0 && value.CompareTo(comparator1) <= 0;
        }
   }

}