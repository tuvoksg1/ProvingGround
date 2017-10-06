using System;
using Pledge.Common.Interfaces;

namespace Pledge.Common.Models.Remote
{
    /// <summary>
    /// Run Time info such as display name, assembly name and class name
    /// </summary>
    public class RemoteJob : InfoSerializer<RemoteJob>, IRemoteJob
    {
        /// <summary>
        /// Gets the job identifier.
        /// </summary>
        /// <value>
        /// The job identifier.
        /// </value>
        public Guid JobId { get; set; }

        /// <summary>
        /// Gets the name of the job.
        /// </summary>
        /// <value>
        /// The name of the job.
        /// </value>
        public string JobName { get; set; }

        /// <summary>
        /// Gets the pledge configuration identifier.
        /// </summary>
        /// <value>
        /// The pledge configuration identifier.
        /// </value>
        public Guid ConfigurationId { get; set; }

        /// <summary>
        /// The ingest medium handler type
        /// </summary>
        public HandlerType IngestHandlerType { get; set; }

        /// <summary>
        /// The egest medium handler type
        /// </summary>
        public HandlerType EgestHandlerType { get; set; }

        /// <summary>
        /// Gets the ingest settings.
        /// </summary>
        /// <value>
        /// The ingest settings.
        /// </value>
        public SerializableDictionary<string, string> IngestMediumSettings { get; set; }

        /// <summary>
        /// Gets the Pledge settings.
        /// </summary>
        /// <value>
        /// The Pledge settings.
        /// </value>
        public SerializableDictionary<string, string> PledgeSettings { get; set; }

        /// <summary>
        /// Gets the egest settings.
        /// </summary>
        /// <value>
        /// The egest settings.
        /// </value>
        public SerializableDictionary<string, string> EgestMediumSettings { get; set; }

        /// <summary>
        /// Creates a copy from the specified original.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <returns>A copy configuration</returns>
        public static RemoteJob Copy(IRemoteJob original)
        {
            if (original == null)
            {
                return null;
            }

            return new RemoteJob
            {
                JobId = Guid.NewGuid(),
                JobName = $"Copy of {original.JobName}",
                ConfigurationId = original.ConfigurationId,
                IngestHandlerType = original.IngestHandlerType,
                EgestHandlerType = original.EgestHandlerType,
                IngestMediumSettings = original.IngestMediumSettings,
                EgestMediumSettings = original.EgestMediumSettings
            };
        }
    }
}
