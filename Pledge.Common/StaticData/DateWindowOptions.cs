using System.ComponentModel;

namespace Pledge.Common.StaticData
{
    /// <summary>
    /// The unit options for the date window rule
    /// </summary>
    public enum DateWindowUnitOptions
    {
        /// <summary>
        /// The target's length is an exact match for a value
        /// </summary>
        [Description("Days")]
        Days,
        /// <summary>
        /// The target's length is less than or equal to a value
        /// </summary>
        [Description("Months")]
        Months,
        /// <summary>
        /// The target's length is greater than or equal to a value
        /// </summary>
        [Description("Years")]
        Years
    }

    /// <summary>
    /// The period options for the date window rule
    /// </summary>
    public enum DateWindowPeriodOptions
    {
        /// <summary>
        /// The target's value is before the window
        /// </summary>
        [Description("Before")]
        Before,
        /// <summary>
        /// The target's value is after the window
        /// </summary>
        [Description("After")]
        After
    }
}
