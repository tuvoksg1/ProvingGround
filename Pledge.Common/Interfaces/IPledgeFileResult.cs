namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// Represents a file system result of a pledge run
    /// </summary>
    /// <seealso cref="IPledgeResult" />
    public interface IPledgeFileResult : IPledgeResult
    {
        /// <summary>
        /// Gets or sets the name of the pass file.
        /// </summary>
        /// <value>
        /// The name of the pass file.
        /// </value>
        string PassFileName { get; set; }
        /// <summary>
        /// Gets or sets the name of the fail file.
        /// </summary>
        /// <value>
        /// The name of the fail file.
        /// </value>
        string FailFileName { get; set; }
    }
}
