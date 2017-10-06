using System.Collections.Generic;
using System.Threading.Tasks;
using Pledge.Common.Auditing;
using Pledge.Common.Models;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Audit interface for logging things like strings, Ipledge types and exceptions
    /// </summary>
    public interface IAuditor
    {
        /// <summary>
        /// Log a string
        /// </summary>
        /// <param name="log"></param>
        void Log(RunLog log);

        /// <summary>
        /// Log a string
        /// </summary>
        /// <param name="messages"></param>
        void Log(List<RunLog> messages);

        /// <summary>
        /// Gets the pledge run logs for user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sortColumn">The sort column.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <returns>
        /// A collection of run logs
        /// </returns>
        Task<RestResult<RunLog>> GetRunLogsForUser(string userName, string tenantId, int pageNumber, int pageSize, string sortColumn, bool ascending);

        /// <summary>
        /// Creates the file process run log.
        /// </summary>
        /// <returns></returns>
        RunLog CreateFileProcessRunLog();
    }
}
