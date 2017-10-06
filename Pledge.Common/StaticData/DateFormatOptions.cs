using System.ComponentModel;

namespace Pledge.Common.StaticData
{
    /// <summary>
    /// Pre-defined date format options
    /// </summary>
    public enum DateFormatOptions
    {
        /// <summary>
        /// Standard English Format
        /// </summary>
        [Description("dd/MM/yyyy")]
        EnglishSlash,
        /// <summary>
        /// Standard American format
        /// </summary>
        [Description("MM/dd/yyyy")]
        AmericanSlash,
        /// <summary>
        /// Based on the ISO standard
        /// </summary>
        [Description("yyyyMMdd")]
        IsoCompact,
        /// <summary>
        /// The full date format
        /// </summary>
        [Description("dd-MM-yyyy")]
        EnglishDash,
        /// <summary>
        /// The short date format
        /// </summary>
        [Description("MM-dd-yyyy")]
        AmericanDash,
        /// <summary>
        /// The offical ISO standard
        /// </summary>
        [Description("yyyy-MM-dd")]
        IsoStandard
    }
}
