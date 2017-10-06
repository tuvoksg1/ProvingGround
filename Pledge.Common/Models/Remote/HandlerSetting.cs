using System.Collections.Generic;

namespace Pledge.Common.Models.Remote
{
    /// <summary>
    /// Default settings for a specific handler
    /// </summary>
    public class HandlerSetting
    {
        /// <summary>
        /// Gets or sets the type of the handler.
        /// </summary>
        public HandlerType HandlerType { get; set; }
        /// <summary>
        /// Gets or sets the default input properties.
        /// </summary>
        public List<Property> InputProperties { get; set; }
        /// <summary>
        /// Gets or sets the default output properties.
        /// </summary>
        public List<Property> OutputProperties { get; set; }
    }
}
