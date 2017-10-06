using System.Collections.Generic;
using System.Configuration;
using System.Xml;

namespace Pledge.Common.Models
{
    /// <summary>
    /// Represents the mapping of data types and rule types
    /// </summary>
    public class RuleMatrix : InfoSerializer<RuleMatrix>, IConfigurationSectionHandler
    {
        /// <summary>
        /// Gets or sets the mappings.
        /// </summary>
        /// <value>
        /// The mappings.
        /// </value>
        public List<DataMap> DataMaps { get; set; }

        /// <summary>
        /// Creates the matrix object from the configuration context.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="configContext">The configuration context.</param>
        /// <param name="section">The section.</param>
        /// <returns>A rule matrix object</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public object Create(object parent, object configContext, XmlNode section)
        {
            var matrix = DeserializeFromXml(section.OuterXml);

            return matrix;
        }
    }
}
