using System.ComponentModel;

namespace Pledge.Common.StaticData
{
    /// <summary>
    /// The options for a TextLength rule
    /// </summary>
    public enum TextLengthOptions
    {
        /// <summary>
        /// The target's length is an exact match for a value
        /// </summary>
        [Description("Equals")]
        Equals,
        /// <summary>
        /// The target's length is greater than or equal to a value
        /// </summary>
        [Description("Is At Least")]
        AtLeast,
        /// <summary>
        /// The target's length is less than or equal to a value
        /// </summary>
        [Description("Is At Most")]
        AtMost
    }
}
