using System;
using Pledge.Common.Models.Remote;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Represents information required to construct and configure a remote pledge component
    /// </summary>
    public interface IRemoteJob
    {
        /// <summary>
        /// Gets the name of the job.
        /// </summary>
        /// <value>
        /// The name of the job.
        /// </value>
        string JobName { get; }
        /// <summary>
        /// Gets the job identifier.
        /// </summary>
        /// <value>
        /// The job identifier.
        /// </value>
        Guid JobId { get;}
        /// <summary>
        /// Gets the pledge configuration identifier.
        /// </summary>
        /// <value>
        /// The pledge configuration identifier.
        /// </value>
        Guid ConfigurationId { get; }
        /// <summary>
        /// The ingest medium handler type
        /// </summary>
        HandlerType IngestHandlerType { get; set; }
        /// <summary>
        /// The egest medium handler type
        /// </summary>
        HandlerType EgestHandlerType { get; set; }
        /// <summary>
        /// Gets the ingest medium settings.
        /// </summary>
        /// <value>
        /// The ingest settings.
        /// </value>
        SerializableDictionary<string, string> IngestMediumSettings { get;}
        /// <summary>
        /// Gets the Pledge settings.
        /// </summary>
        /// <value>
        /// The Pledge settings.
        /// </value>
        SerializableDictionary<string, string> PledgeSettings { get; }
        /// <summary>
        /// Gets the egest medium settings.
        /// </summary>
        /// <value>
        /// The egest settings.
        /// </value>
        SerializableDictionary<string, string> EgestMediumSettings { get; }
    }
}
