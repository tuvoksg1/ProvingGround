using System.Collections.Generic;
using System.Configuration;
using System.Xml;

namespace Pledge.Common.Models.Remote
{
    /// <summary>
    /// A mapping of default settings and handler types
    /// </summary>
    public class PropertyMatrix : InfoSerializer<PropertyMatrix>, IConfigurationSectionHandler
    {
        /// <summary>
        /// Gets or sets the default handler settings.
        /// </summary>
        /// <value>
        /// The default handler settings.
        /// </value>
        public List<HandlerSetting> DefaultSettings { get; set; }

        /// <summary>
        /// Creates the matrix object from the configuration context.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="configContext">The configuration context.</param>
        /// <param name="section">The section.</param>
        /// <returns>A property matrix object</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public object Create(object parent, object configContext, XmlNode section)
        {
            var matrix = DeserializeFromXml(section.OuterXml);

            return matrix;
        }
    }
}
