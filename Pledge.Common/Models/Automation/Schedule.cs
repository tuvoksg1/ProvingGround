using System;
using System.Collections.Generic;

namespace Pledge.Common.Models.Automation
{
    /// <summary>
    /// The schedule of a workflow object
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        public Interval Interval { get; set; }
        /// <summary>
        /// Gets or sets the frequency.
        /// </summary>
        public int Frequency { get; set; }
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is disabled.
        /// </summary>
        public bool IsDisabled { get; set; }
        /// <summary>
        /// Gets or sets the days.
        /// </summary>
        public List<DayOfTheWeek> Days { get; set; }
    }

    /// <summary>
    /// Represents a selectable calendar day
    /// </summary>
    public class DayOfTheWeek
    {
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        public bool IsSelected { get; set; }
    }
}
