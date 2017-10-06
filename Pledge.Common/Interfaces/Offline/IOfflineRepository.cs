namespace Pledge.Common.Interfaces.Offline
{
    /// <summary>
    /// A repository capable of retrieving Pledge-related data without internet access
    /// </summary>
    public interface IOfflineRepository
    {
        /// <summary>
        /// Gets the specified job.
        /// </summary>
        /// <param name="jobId">The job identifier.</param>
        /// <returns>The data required to build the job</returns>
        IJobData GetJob(string jobId);

        /// <summary>
        /// Saves the specified job.
        /// </summary>
        /// <param name="data">The data to be saved.</param>
        void SaveJob(IJobData data);
    }
}
