using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using CXUtils.Serialization;

namespace Pledge.Common.Models.Automation
{
    /// <summary>
    /// A mapping of automation categories and task types
    /// </summary>
    public class AutomationMatrix : DataXmlSerializer<AutomationMatrix>, IConfigurationSectionHandler
    {
        /// <summary>
        /// Gets or sets the automation categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public List<CategoryMap> Categories { get; set; }

        /// <summary>
        /// Creates the matrix object from the configuration context.
        /// </summary>
        /// <param name="parent">Parent object.</param>
        /// <param name="configContext">Configuration context.</param>
        /// <param name="section">Xml section node.</param>
        /// <returns>
        /// An automation matrix object
        /// </returns>
        public object Create(object parent, object configContext, XmlNode section)
        {
            var matrix = DeserializeFromXml(section.OuterXml);

            return matrix;
        }
    }
}
