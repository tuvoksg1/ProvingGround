using Pledge.Common.Auditing;

namespace Pledge.Common.Interfaces.Offline
{
    /// <summary>
    /// A component capable of logging audit information without requiring internet access
    /// </summary>
    public interface IOfflineAuditor
    {
        /// <summary>
        /// Saves the audit data.
        /// </summary>
        /// <param name="auditLog">The audit log.</param>
        void SaveAuditData(RunLog auditLog);
    }
}