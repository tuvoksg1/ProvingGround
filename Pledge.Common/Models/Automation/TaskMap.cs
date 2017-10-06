namespace Pledge.Common.Models.Automation
{
    /// <summary>
    /// Represents an automation task along with all the information to visually represent and construct it
    /// </summary>
    public class TaskMap
    {
        /// <summary>
        /// Gets or sets the type of the task.
        /// </summary>
        public TaskType Type { get; set; }
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// Gets or sets the template used to edit the task parameters.
        /// </summary>
        public string EditTemplate { get; set; }

        /// <summary>
        /// Gets or sets the layout template.
        /// </summary>
        public string LayoutTemplate { get; set; }

        /// <summary>
        /// Gets or sets the Angular controller used to edit the task parameters.
        /// </summary>
        public string EditController { get; set; }

        /// <summary>
        /// Gets or sets the options list.
        /// </summary>
        public string OptionsList { get; set; }
    }
}
