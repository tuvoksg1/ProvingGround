using Pledge.Common.Models;
using System;
using System.Collections.Generic;
using Pledge.Common.Models.Remote;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Pledge Manager interface
    /// </summary>
    public interface IPledgeManager
    {
        /// <summary>
        /// Gets the list of available configurations.
        /// </summary>
        /// <param name="userId">Logged in user</param>
        /// <param name="tenantId">GroupId of the user logged in</param>
        /// <returns>A collection of available configurations</returns>
        IEnumerable<ConfigurationCore> GetConfigurations(Guid userId, Guid tenantId);

        /// <summary>
        /// Gets the named configuration.
        /// </summary>
        /// <param name="configurationId">The identifier.</param>
        /// <param name="userId">Id of the user.</param>
        /// <param name="tenantId">Organisation of the user.</param>
        /// <returns>
        /// A configuration
        /// </returns>
        IConfiguration GetConfiguration(Guid configurationId, Guid userId, Guid tenantId);

        /// <summary>
        /// Saves the changes to a configuration.
        /// </summary>
        /// <param name="configuration">The configuration to save.</param>
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
        /// Executes the specified configuration by reading from the specified import
        /// location and writing to the specified output location.
        /// </summary>
        /// <param name="configurationId">Id of the configuration.</param>
        /// <param name="userName">Name of the user running pledge.</param>
        /// <param name="job">The job model.</param>
        /// <param name="clientId">SignalR clientId</param>
        /// <param name="userId">The Web Session ID</param>
        /// <param name="tenantId">Organisation id of the user.</param>
        /// <param name="tenantCode">Organisation code of the user.</param>
        /// <returns>
        /// True if the process passed validation, else false
        /// </returns>
        IPledgeResult Execute(Guid configurationId, string userName, IRemoteJob job, string clientId, 
             Guid userId, Guid tenantId, string tenantCode);

        /// <summary>
        /// Returns the matrix of configured rules in the system
        /// </summary>
        /// <returns>A rule matrix</returns>
        RuleMatrix GetRuleMatrix();

        /// <summary>
        /// Imports a configuration from the specified file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="userId">Name of the user importing the configuration.</param>
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
        /// <param name="userName">Logged in user</param>
        /// <param name="tenantId">The Organisation of the user.</param>
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
        /// Saves the remote job with the specified identifier.
        /// </summary>
        /// <param name="remoteJob">The job configuration.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="tenantId">Organisation of the user.</param>
        void SaveRemoteJob(IRemoteJob remoteJob, Guid userId, Guid tenantId);

        /// <summary>
        /// Creates a copy of the specified job.
        /// </summary>
        /// <param name="jobId">The configuration identifier.</param>
        /// <param name="userId">Id of the user making the update.</param>
        /// <param name="tenantId">Organisation of the user.</param>
        void CopyRemoteJob(Guid jobId, Guid userId, Guid tenantId);

        /// <summary>
        /// Gets the property matrix.
        /// </summary>
        /// <returns></returns>
        PropertyMatrix GetPropertyMatrix();


    }
}
