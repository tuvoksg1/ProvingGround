using System.ComponentModel;

namespace Pledge.Common.StaticData
{

 /// <summary>
 /// Options for special characters
 /// </summary>
    public enum RandomSpecialOptions
    {
        /// <summary>
        /// Include this option
        /// </summary>
        [Description("At Least One")]
        Include,
        /// <summary>
        /// Exclude this option
        /// </summary>
        [Description("Unrestricted")]
        Exclude
    }
    /// <summary>
    /// Options for Number options
    /// </summary>
    public enum RandomNumberOptions
    {
        /// <summary>
        /// Include this option
        /// </summary>
        [Description("At Least One")]
        Include,
        /// <summary>
        /// Exclude this option
        /// </summary>
        [Description("Unrestricted")]
        Exclude
    }
    /// <summary>
    /// Options for upper case characters
    /// </summary>
    public enum RandomUpperCaseOptions
    {
        /// <summary>
        /// Include this option
        /// </summary>
        [Description("At Least One")]
        Include,
        /// <summary>
        /// Exclude this option
        /// </summary>
        [Description("Unrestricted")]
        Exclude
    }
}
