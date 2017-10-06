using System.Collections.Generic;

namespace Pledge.Common.Models.Automation
{
    /// <summary>
    /// A mapping of automation categories to tasks
    /// </summary>
    public class CategoryMap
    {
        /// <summary>
        /// Gets or sets the type of the category.
        /// </summary>
        public CategoryType Type { get; set; }

        /// <summary>
        /// Gets or sets the tasks for this category.
        /// </summary>
        public List<TaskMap> TaskMaps { get; set; }
    }
}