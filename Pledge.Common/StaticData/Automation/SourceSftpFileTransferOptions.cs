using System.ComponentModel;

namespace Pledge.Common.StaticData.Automation
{
    /// <summary>
    /// Download options for input for processing run 
    /// </summary>
    public enum SourceSftpFileTransferOptions
    {

        /// <summary>
        /// Delete the source file (default)
        /// </summary>
        [Description("Remove")]
        Remove,

        /// <summary>
        /// Leave the source file 
        /// </summary>
        [Description("Leave on server")]
        LeaveOnServer

        

    }
}
