namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// A file system egest medium
    /// </summary>
    public interface IFileEgestMedium
    {
        /// <summary>
        /// Gets the name of the pass file.
        /// </summary>
        /// <value>
        /// The name of the pass file.
        /// </value>
        string PassFileName { get; }
        /// <summary>
        /// Gets the name of the fail file.
        /// </summary>
        /// <value>
        /// The name of the fail file.
        /// </value>
        string FailFileName { get; }
    }
}
