using System.Configuration;
using System.Xml;
using System.Xml.Serialization;

namespace Pledge.Common.Models.Remote
{
    /// <summary>
    /// A configuration of the Pledge runtime settings
    /// </summary>
    /// <seealso cref="Common.InfoSerializer{PledgeRuntime}" />
    /// <seealso cref="IConfigurationSectionHandler" />
    public class PledgeRuntime : InfoSerializer<PledgeRuntime>, IConfigurationSectionHandler
    {
        /// <summary>
        /// Gets or sets the version of the runtime.
        /// </summary>
        [XmlAttribute("Version")]
        public int Version { get; set; }
        /// <summary>
        /// Gets or sets the mode of this runtime.
        /// </summary>
        public RuntimeMode Mode { get; set; }
        /// <summary>
        /// Gets or sets the remote settings.
        /// </summary>
        public RemoteRuntimeSettings RemoteSettings { get; set; }
        /// <summary>
        /// Gets or sets the local settings.
        /// </summary>
        public LocalRuntimeSettings LocalSettings { get; set; }

        /// <summary>
        /// Creates a runtime object from the configuration context.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="configContext">The configuration context.</param>
        /// <param name="section">The section.</param>
        /// <returns>A pledge runtime instance</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public object Create(object parent, object configContext, XmlNode section)
        {
            var runtime = DeserializeFromXml(section.OuterXml);

            return runtime;
        }
    }
}
