using System.Collections.Generic;

namespace Pledge.Common.Models.Lookup
{
    /// <summary>
    /// A list of string-based data
    /// </summary>
    public class List
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="List"/> class.
        /// </summary>
        public List()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="List"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public List(IEnumerable<string> collection)
        {
            Content = new List<string>(collection);
        }

        /// <summary>
        /// Gets or sets the content of the list.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public List<string> Content { get; set; }

        /// <summary>
        /// Gets or sets the content of the list (byte arrary).
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public byte[] FileData { get; set; }

        /// <summary>
        /// Gets or sets the type of list.
        /// </summary>
        public ListType Type { get; set; }

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
        /// Gets or sets Separator
        /// </summary>
        public string Separator { get; set; }

        /// <summary>
        /// Gets or sets the tenant id.
        /// </summary>
        public string TenantId { get; set; }
    }
}
