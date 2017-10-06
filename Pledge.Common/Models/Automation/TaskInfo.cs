using CXUtils.Extensions;

namespace Pledge.Common.Models.Automation
{
    /// <summary>
    /// Visual representation of a workflow task
    /// </summary>
    public class TaskInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskInfo"/> class.
        /// </summary>
        /// <param name="task">The task.</param>
        public TaskInfo(TaskMap task)
        {
            TaskType = task.Type;
            Icon = task.Icon;
            Description = task.Type.GetDescription();
            LayoutTemplate = task.LayoutTemplate;
            EditTemplate = task.EditTemplate;
            EditController = task.EditController;
            OptionsList = task.OptionsList;
        }

        /// <summary>
        /// Gets or sets the type of the task.
        /// </summary>
        public TaskType TaskType { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

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
        /// Gets or sets the options list for dropdwon, radio or check box controls.
        /// </summary>
        public string OptionsList { get; set; }
    }
}
