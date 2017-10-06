using System.Threading.Tasks;
using Pledge.Common.Auditing;
using Pledge.Common.Models;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// The rest client for the Auditing service
    /// </summary>
    public interface IAuditorRestClient
    {
        /// <summary>
        /// Posts the log to the message queue.
        /// </summary>
        /// <param name="log">The log.</param>
        void PostLog(RunLog log);

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
    }
}
