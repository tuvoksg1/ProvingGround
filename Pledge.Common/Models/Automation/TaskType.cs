using System.ComponentModel;

namespace Pledge.Common.Models.Automation
{
    /// <summary>
    /// Holds available Automation categories
    /// </summary>
    public enum TaskType
    {
        /// <summary>
        /// SFTP Download type 
        /// </summary>
        [Description("From SFTP")]
        SftpDownload,

        /// <summary>
        /// SFTP Upload type 
        /// </summary>
        [Description("To SFTP")]
        SftpUpload,

        /// <summary>
        /// Pledge Run type
        /// </summary>
        [Description("Pledge Run")]
        PledgeRun,

        /// <summary>
        /// Setup task type
        /// </summary>
        [Description("Setup")]
        Setup = 997,

        /// <summary>
        /// Teardown task type
        /// </summary>
        [Description("Teardown")]
        Teardown = 998,

        /// <summary>
        /// The unsupported task type
        /// </summary>
        [Description("Unsupported")]
        Unsupported = 999
    }
}
