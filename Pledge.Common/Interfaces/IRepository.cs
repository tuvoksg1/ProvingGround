using System;
using System.Collections.Generic;
using Pledge.Common.Models;
using Pledge.Common.Models.Remote;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Repository Interface
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets the available configurations.
        /// </summary>
        /// <param name="userId">Id of the user.</param>
        /// <param name="tenantId">The Organisation if the user</param>
        /// <returns></returns>
        IEnumerable<ConfigurationCore> GetConfigurations(Guid userId, Guid tenantId);
        /// <summary>
        /// Get Configuration
        /// </summary>
        /// <param name="configurationId"></param>
        /// <returns>returns a string with the config info</returns>
        ConfigurationInfo GetConfiguration(Guid configurationId);
        /// <summary>
        /// Save method for configuration
        /// </summary>
        /// <param name="configurationId">The configuration identifier.</param>
        /// <param name="versionNumber">The version number.</param>
        /// <param name="configurationName">Name of the configuration.</param>
        /// <param name="configurationSettings">The configuration settings.</param>
        /// <param name="author">The author.</param>
        /// <param name="description">The description.</param>
        /// <param name="userId">Id of the user.</param>
        /// <param name="tenantId">Organisation of the user.</param>
        void Save(Guid configurationId, int versionNumber, string configurationName, string configurationSettings, string author, string description, Guid userId, Guid tenantId);
        
        /// <summary>
        /// Deletes the configuration.
        /// </summary>
        /// <param name="configurationId">The configuration identifier.</param>
        void DeleteConfiguration(Guid configurationId);

        
        /// <summary>
        /// Gets the remote jobs.
        /// </summary>
        /// <param name="author">Logged in user</param>
        /// <param name="tenantId">The Organisation of the user.</param>
        /// <returns></returns>
        IEnumerable<string> GetRemoteJobs(string author, Guid tenantId);

        /// <summary>
        /// Gets the remote job with the specified Id.
        /// </summary>
        /// <param name="jobId">The job identifier.</param>
        /// <returns></returns>
        RemoteJobInfo GetRemoteJob(Guid jobId);

        /// <summary>
        /// Deletes the remote job.
        /// </summary>
        /// <param name="jobId">The job identifier.</param>
        void DeleteRemoteJob(Guid jobId);

        /// <summary>
        /// Saves the job with the specified identifier.
        /// </summary>
        /// <param name="jobId">The job identifier.</param>
        /// <param name="configurationId">The configuration identifier.</param>
        /// <param name="jobName">Name of the job.</param>
        /// <param name="jobSettings">The job settings.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="tenantId">Organisation of the user.</param>
        void Save(Guid jobId, Guid configurationId, string jobName, string jobSettings, Guid userId, Guid tenantId);
    }
}
