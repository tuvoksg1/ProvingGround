using System;
using CXUtils.Serialization;

namespace Pledge.Common.Models.Lookup
{
    /// <summary>
    /// Information about the list
    /// </summary>
    public class ListMetadata : DataJsonSerializer<ListMetadata>
    {
        /// <summary>
        /// Identifier of the list
        /// </summary>
        public string ListId { get; set; }
        /// <summary>
        /// Name of the list
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description of the list
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Location of the list file
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Content type of the list
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Separator for multiple column lists
        /// </summary>
        public string Separator { get; set; }
        /// <summary>
        /// Who last updated the list
        /// </summary>
        public string UpdatedBy { get; set; }
        /// <summary>
        /// Date of last update
        /// </summary>
        public DateTime LastUpdated { get; set; }
    }
}
