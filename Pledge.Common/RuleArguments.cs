using System;
using System.Collections.Generic;
using Pledge.Common.Interfaces;
using Pledge.Common.Interfaces.Lookup;
using Pledge.Common.Models;

namespace Pledge.Common
{
    /// <summary>
    /// Rule arg class to abstract the creation of rules
    /// </summary>
    public class RuleArguments
    {
        /// <summary>
        /// Rule arg class constructor to abstract the creation of rules
        /// </summary>
        /// <param name="ruleId"></param>
        /// <param name="dataType"></param>
        /// <param name="description"></param>
        /// <param name="operands"></param>
        /// <param name="childRules"></param>
        /// <param name="logicType"></param>
        /// <param name="mode"></param>
        /// <param name="failureCode"></param>
        /// <param name="listProxy"></param>
        /// <param name="tenantId"></param>
        public RuleArguments(Guid ruleId, DataType dataType, string description, IReadOnlyList<IOperand> operands, IReadOnlyList<IRule> childRules, 
            LogicType logicType, EvaluationMode mode, string failureCode, IListProxy listProxy, string tenantId)
        {
            RuleId = ruleId;
            DataType = dataType;
            Description = description;
            Operands = operands;
            ChildRules = childRules;
            LogicType = logicType;
            Mode = mode;
            FailureCode = failureCode;
            ListProxy = listProxy;
            TenantId = tenantId;
        }

        /// <summary>
        /// Rule id 
        /// </summary>
        public Guid RuleId { get; }

        /// <summary>
        /// Rule data type
        /// </summary>
        public DataType DataType { get; }

        /// <summary>
        /// Rule description
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Operand
        /// </summary>
        public IReadOnlyList<IOperand> Operands { get;}

        /// <summary>
        /// Child Rule
        /// </summary>
        public IReadOnlyList<IRule> ChildRules { get;}

        /// <summary>
        /// Logic MessageType like AND, OR
        /// </summary>
        public LogicType LogicType { get;}

        /// <summary>
        /// The mode used to evaluate a rule
        /// </summary>
        public EvaluationMode Mode { get;}

        /// <summary>
        /// Failure code of a rule that may or may not be provided
        /// </summary>
        public string FailureCode { get;}

        /// <summary>
        /// Proxy for the external list
        /// </summary>
        public IListProxy ListProxy { get; }

        /// <summary>
        /// Tenant id
        /// </summary>
        public string TenantId { get; }
    }
}
