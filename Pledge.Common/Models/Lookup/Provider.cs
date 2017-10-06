using System.Xml.Serialization;

namespace Pledge.Common.Models.Lookup
{
    /// <summary>
    /// Represents information about a list provider
    /// </summary>
    public class Provider
    {
        /// <summary>
        /// Gets or sets the namespace.
        /// </summary>
        [XmlAttribute]
        public string Namespace { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [XmlAttribute]
        public ListType Type { get; set; }
    }
}
