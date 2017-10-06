namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Builder interface to create objects like the repository, pledge, auditors and configuration managers
    /// </summary>
    public interface IBuilder
    {
        /// <summary>
        /// Creates a pledge pipeline.
        /// </summary>
        /// <param name="jobConfiguration">The job configuration.</param>
        /// <param name="pledgeConfiguration">The pledge configuration.</param>
        /// <param name="auditor">The auditor.</param>
        /// <param name="tenantId">The tenant identifier</param>
        /// <returns>
        /// A Pledge pipeline
        /// </returns>
        IPipelineHead CreatePipeline(IRemoteJob jobConfiguration, IConfiguration pledgeConfiguration, IAuditor auditor, string tenantId);
    }
}