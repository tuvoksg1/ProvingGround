using System.ComponentModel;

namespace Pledge.Common.StaticData
{
    /// <summary>
    /// The options for Text External list options, Text In Externallist Rule
    /// 
    /// </summary>
    public enum TransformLookupOptions
    {
        /// <summary>
        /// The text is found at the exact position of the target, 
        /// also defaults on new configs.
        /// </summary>
        [Description("Exact")]
        Exact,
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

    /// <summary>
    /// The options for Replace options for the target.
    /// </summary>
    public enum TransformLookupReplaceOptions
    {
        /// <summary>
        /// Default option to match and replace all characters 
        /// from the source to the target.
        /// </summary>
        [Description("All")]
        ReplaceAll,
        /// <summary>
        /// Option to match and replace only matched characters 
        /// from the source to the target.
        /// </summary>
        [Description("Matched Characters")]
        ReplaceMatched
    }
}
