using Pledge.Common.Interfaces;

namespace Pledge.Common.Models
{
    /// <summary>
    /// A file system result for a pledge run
    /// </summary>
    /// <seealso cref="PledgeResult" />
    /// <seealso cref="IPledgeFileResult" />
    public class PledgeIOResult : PledgeResult, IPledgeFileResult
    {
        /// <summary>
        /// Gets or sets the name of the pass file.
        /// </summary>
        /// <value>
        /// The name of the pass file.
        /// </value>
        public string PassFileName { get; set; }
        /// <summary>
        /// Gets or sets the name of the fail file.
        /// </summary>
        /// <value>
        /// The name of the fail file.
        /// </value>
        public string FailFileName { get; set; }
    }
}
