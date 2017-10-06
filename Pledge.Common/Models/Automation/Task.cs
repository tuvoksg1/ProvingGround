namespace Pledge.Common.Models.Automation
{
    /// <summary>
    /// An automation workflow task
    /// </summary>
    public class Task
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
        /// Gets or sets the type.
        /// </summary>
        public TaskType Type { get; set; }
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// Gets or sets the properties required to run this task.
        /// </summary>
        public dynamic Properties { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Task"/> is started.
        /// </summary>
        public bool Started { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Task"/> Succeeded.
        /// </summary>
        public bool Succeeded { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Task"/> is failed.
        /// </summary>
        public bool Failed { get; set; }
        /// <summary>
        /// Gets or sets the progress of the task.
        /// </summary>
        public int Progress { get; set; }
    }
}
