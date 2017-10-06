using System;
using System.Collections.Generic;
using Pledge.Common.Models;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Configuration interface
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        /// Id property : READ ONLY
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets the version identifier.
        /// </summary>
        int VersionId { get; }

        /// <summary>
        /// Gets the group identifier.
        /// </summary>
        string GroupId { get; }

        /// <summary>
        /// Gets the group name.
        /// </summary>
        string GroupName { get; }

        /// <summary>
        /// Name property
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///Author property to record the author of the configuaration
        /// </summary>
        string Author { get; set; }

        /// <summary>
        /// Configuration description property
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Base document model for the configuration : READ ONLY
        /// </summary>
        BaseDocument Model { get; }

        /// <summary>
        /// Property to hold the rules  : READ ONLY
        /// </summary>
        List<PledgeRule> Rules { get; }
    }
}
