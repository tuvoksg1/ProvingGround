using System.ComponentModel;

namespace Pledge.Common.Models.Automation
{
    /// <summary>
    /// Interval between workflow runs
    /// </summary>
    public enum Interval
    {
        /// <summary>
        /// The minutely interval
        /// </summary>
        [Description("Minutes")]
        Minutely,
        /// <summary>
        /// The hourly interval
        /// </summary>
        [Description("Hourly")]
        Hourly,
        /// <summary>
        /// The daily interval
        /// </summary>
        [Description("Daily")]
        Daily,
        /// <summary>
        /// The weekly interval
        /// </summary>
        [Description("Weekly")]
        Weekly
    }
}
