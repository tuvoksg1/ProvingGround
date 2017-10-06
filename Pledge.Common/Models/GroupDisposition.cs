using Pledge.Common.Interfaces;

namespace Pledge.Common.Models
{
    /// <summary>
    /// Class object to contains the highlest level group failure code and with the aggregated results.
    /// </summary>
    public class GroupDisposition : IGroupDisposition
    {
        /// <summary>
        /// Highest group failure code property.
        /// </summary>
        public string FailureCode { get; set; }
        /// <summary>
        /// Aggregated rule results property.
        /// </summary>
        public IResult AggregateResult { get; set; }

    }
}