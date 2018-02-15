using System;

namespace DynamicContainer
{
    /// <summary>
    /// VM for List class
    /// </summary>
    public class ListViewModel
    {
        /// <summary>
        /// Gets or sets the type of list.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the id of the list.
        /// </summary>
        public string ListId { get; set; }

        /// <summary>
        /// Gets or sets the name of the list.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the list.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the function of the list.
        /// </summary>
        public string Function { get; set; }

        /// <summary>
        /// Gets or sets the separator of the list.
        /// </summary>
        public string Separator { get; set; }

        /// <summary>
        /// Gets or sets the date and time the list was locked.
        /// </summary>
        public DateTime? EditLocked { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public ResourceState State { get; set; }
        /// <summary>
        /// Gets or sets the Id of the user who locked the list.
        /// </summary>
        public string EditLockedById { get; set; }

        /// <summary>
        /// /// Gets or sets the name of the user who locked the list.
        /// </summary>
        public string EditLockedByUser { get; set; }

        /// <summary>
        /// Gets or sets the user to last updated the list
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Date of last update
        /// </summary>
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets the last filename
        /// </summary>
        public string LastSavedFileName { get; set; }
    }
}
