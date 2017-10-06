using System.ComponentModel;

namespace Pledge.Common.StaticData
{
    /// <summary>
    /// The options for a TextContains, Text NotContain rule
    /// </summary>
    public enum TextContainsOptions
    {
        /// <summary>
        /// The text is found anywhere in the target
        /// </summary>
        [Description("Anywhere")]
        Anywhere,
        /// <summary>
        /// The text is found at the beginning of the target
        /// </summary>
        [Description("At Start")]
        StartsWith,
        /// <summary>
        /// The text is found at the end of the target
        /// </summary>
        [Description("At End")]
        EndsWith
    }
}
