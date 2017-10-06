using System;
using System.Collections.Generic;
using Pledge.Common.Models;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Configuration manager interface
    /// </summary>
    public interface IConfigurationManager
    {
        /// <summary>
        /// Get a configuration
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tenantId"></param>
        /// <returns> enumation of IConfigurations</returns>
        IEnumerable<ConfigurationCore> GetConfigurations(Guid userId, Guid tenantId);

        /// <summary>
        /// Get a single configuration
        /// </summary>
        /// <param name="configurationId">The configuration identifier.</param>
        /// <param name="userId">Id of the user.</param>
        /// <param name="tenantId">Organisation of the user.</param>
        /// <returns>
        /// IConfiguration object
        /// </returns>
        IConfiguration GetConfiguration(Guid configurationId, Guid userId, Guid tenantId);

        /// <summary>
        /// Save a configuration
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="userId">Id of the user making the update.</param>
        /// <param name="tenantId">Organisation of the user.</param>
        void SaveConfiguration(IConfiguration configuration, Guid userId, Guid tenantId);

        /// <summary>
        /// Deletes the configuration.
        /// </summary>
        /// <param name="configurationId">The configuration identifier.</param>
        /// <param name="userId">Id of the user making the update.</param>
        void DeleteConfiguration(Guid configurationId, Guid userId);

        /// <summary>
        /// Creates a copy of the specified configuration.
        /// </summary>
        /// <param name="configurationId">The configuration identifier.</param>
        /// <param name="author">The author.</param>
        /// <param name="userId">Id of the user making the update.</param>
        /// <param name="tenantId">Organisation of the user.</param>
        void CopyConfiguration(Guid configurationId, string author, Guid userId, Guid tenantId);

        /// <summary>
        /// Imports a configuration from the specified file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="userId">Id of the user importing the configuration.</param>
        /// <param name="tenantId">Organisation of the user.</param>
        /// <returns>
        /// True, if the import was successful, else false
        /// </returns>
        bool ImportConfiguration(string filePath, Guid userId, Guid tenantId);

        /// <summary>
        /// Exports the configuration to the specified file path.
        /// </summary>
        /// <param name="configurationId">The configuration identifier.</param>
        /// <param name="filePath">The file path.</param>
        /// <param name="userId">Id of the user.</param>
        /// <param name="tenantId">Organisation of the user.</param>
        /// <returns></returns>
        bool ExportConfiguration(Guid configurationId, string filePath, Guid userId, Guid tenantId);

        /// <summary>
        /// Gets the remote jobs.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        IEnumerable<IRemoteJob> GetRemoteJobs(string userName, Guid tenantId);

        /// <summary>
        /// Gets the information required to schedule and
        /// invoke the remote job with the specified Id.
        /// </summary>
        /// <param name="jobId">The job identifier.</param>
        /// <param name="userId">Id of the user.</param>
        /// <param name="tenantId">Organisation of the user.</param>
        /// <returns></returns>
        IJobData GetRemoteJobInfo(Guid jobId, Guid userId, Guid tenantId);

        /// <summary>
        /// Deletes the remote job.
        /// </summary>
        /// <param name="jobId">The job identifier.</param>
        /// <param name="userId">The user identifier.</param>
        void DeleteRemoteJob(Guid jobId, string userId);

        /// <summary>
        /// Saves the job with the specified identifier.
        /// </summary>
        /// <param name="remoteJob">The job configuration.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="tenantId">Organisation of the user.</param>
        void SaveRemoteJob(IRemoteJob remoteJob, Guid userId, Guid tenantId);

        /// <summary>
        /// Creates a copy of the specified job.
        /// </summary>
        /// <param name="jobId">The job identifier.</param>
        /// <param name="userId">Id of the user making the update.</param>
        /// <param name="tenantId">Organisation of the user.</param>
        void CopyRemoteJob(Guid jobId, Guid userId, Guid tenantId);
    }
}
