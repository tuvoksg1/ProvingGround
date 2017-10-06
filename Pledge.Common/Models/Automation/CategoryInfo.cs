using System.Collections.Generic;
using System.Linq;
using CXUtils.Extensions;

namespace Pledge.Common.Models.Automation
{
    /// <summary>
    /// Visual representation of a workflow task category
    /// </summary>
    public class CategoryInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryInfo"/> class.
        /// </summary>
        /// <param name="type">The category type.</param>
        /// <param name="tasks">The tasks.</param>
        public CategoryInfo(CategoryType type, IEnumerable<TaskMap> tasks)
        {
            CategoryType = type;
            Description = type.GetDescription();
            TaskTypes =
                tasks.Select(
                    arg =>
                        new TaskInfo(arg))
                    .ToList();
        }

        /// <summary>
        /// Gets or sets the type of the category.
        /// </summary>
        public CategoryType CategoryType { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the task types for this category.
        /// </summary>
        public List<TaskInfo> TaskTypes { get; set; }
    }
}
