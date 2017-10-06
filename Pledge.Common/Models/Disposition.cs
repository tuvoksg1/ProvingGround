using Pledge.Common.Interfaces;

namespace Pledge.Common.Models
{
    /// <summary>
    /// Contains error message and code associated with a rule.
    /// </summary>
    public class Disposition : IDisposition
    {
        /// <summary>
        /// Error message associated with a rule failure.
        /// </summary>
        public string Annotation { get; set; }
        /// <summary>
        /// Code associated with a rule failure.
        /// </summary>
        public string FailureCode { get; set; }
    }
}
