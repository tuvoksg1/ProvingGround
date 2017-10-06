using System.ComponentModel;

namespace Pledge.Common.StaticData
{
    /// <summary>
    /// The options for a TextContains rule
    /// </summary>
    public enum AppendValueOptions
    {
        /// <summary>
        /// Append value at the beginning of the target
        /// </summary>
        [Description("At Start")]
        Start,
        /// <summary>
        /// Append value at the end of the target
        /// </summary>
        [Description("At End")]
        End
    }
}