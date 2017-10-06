using System.Collections.Generic;

namespace Pledge.Common.Models.Automation
{
    /// <summary>
    /// A model of the VisualCron Job
    /// </summary>
    public class Workflow
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Workflow"/> is started.
        /// </summary>
        public bool Started { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Workflow"/> is completed.
        /// </summary>
        public bool Completed { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Workflow"/> is failed.
        /// </summary>
        public bool Failed { get; set; }
        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        public List<Task> Tasks { get; set; }
        /// <summary>
        /// Gets or sets the schedule for this workflow.
        /// </summary>
        public Schedule Schedule { get; set; }
    }
}