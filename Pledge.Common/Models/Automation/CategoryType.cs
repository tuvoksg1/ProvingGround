using System.ComponentModel;

namespace Pledge.Common.Models.Automation
{
    /// <summary>
    /// Holds available Automation categories
    /// </summary>
    public enum CategoryType
    {
        /// <summary>
        /// Connect Category 
        /// </summary>
        [Description("Connect")]
        Connect = 0,

        /// <summary>
        /// Process Category
        /// </summary>
        [Description("Process")]
        Process = 1
    }
}