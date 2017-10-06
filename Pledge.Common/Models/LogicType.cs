using System.Runtime.Serialization;

namespace Pledge.Common.Models
{
    /// <summary>
    /// The logic type to be applied to a rule's result
    /// </summary>
    public enum LogicType
    {
        /// <summary>
        /// Represents an AND logic for a rule's result
        /// </summary>
        [EnumMember]
        And = 0,
        /// <summary>
        /// Represents an OR logic for a rule's result
        /// </summary>
        [EnumMember]
        Or = 1
    }
}
