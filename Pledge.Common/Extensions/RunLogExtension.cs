using Pledge.Common.Auditing;
using Pledge.Common.Exceptions;
using Pledge.Common.Models;

namespace Pledge.Common.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class RunLogExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public static bool IsValid(this RunLog log)
        {
            if (null == log) return false;

            // String 
            if (string.IsNullOrWhiteSpace(log.TenantIdKey)) throw new PledgeRunException("Tenant ID is not valid."); 
            if (string.IsNullOrWhiteSpace(log.MessageType)) throw new PledgeRunException("Audit Message Type is not valid.");
            if (string.IsNullOrWhiteSpace(log.UserIdKey)) throw new PledgeRunException("User ID is not valid."); 

            if (log.MessageType == PledgeGlobal.MessageTypeException && 
                string.IsNullOrWhiteSpace(log.ErrorMessage))
            {
                throw new PledgeRunException("No error message found for Exception Message Type."); 
            }

            // numbers
            if (log.NumberOfRows < 0) throw new PledgeRunException("Total number of rows are less than zero.");
            if (log.NumberOfPasses < 0) throw new PledgeRunException("Number of passed rows are less than zero."); 
            if (log.NumberOfFailures < 0) throw new PledgeRunException("Number of failed rows are less than zero.");

            return true;
        }
    }
}