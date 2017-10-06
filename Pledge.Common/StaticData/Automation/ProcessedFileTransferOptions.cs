using System.ComponentModel;

namespace Pledge.Common.StaticData.Automation
{
    /// <summary>
    /// Upload options for output from a processing run
    /// </summary>
    public enum ProcessedFileTransferOptions
    {
        /// <summary>
        /// Upload only passing files
        /// </summary>
        [Description("Passes only")]
        PassFilesOnly,
        /// <summary>
        /// Upload only failing files
        /// </summary>
        [Description("Failures only")]
        FailFilesOnly,
        /// <summary>
        /// Upload both passing and failing files
        /// </summary>
        [Description("Both files")]
        AllFiles
    }
}
