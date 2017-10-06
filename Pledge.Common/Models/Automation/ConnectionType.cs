using System.ComponentModel;

namespace Pledge.Common.Models.Automation
{
    /// <summary>
    /// Represents the type of a visual cron
    /// </summary>
    public enum ConnectionType
    {
        /// <summary>
        /// An SFTP Connection
        /// </summary>
        [Description("SFTP")]
        Sftp,
        /// <summary>
        /// An FTP Connection
        /// </summary>
        [Description("FTP")]
        Ftp,
        /// <summary>
        /// An SMTP Connection
        /// </summary>
        [Description("Email")]
        Email,
        /// <summary>
        /// A Cloud storage connection
        /// </summary>
        [Description("Cloud")]
        Cloud,
        /// <summary>
        /// An unsupported connection type
        /// </summary>
        [Description("Unsupported")]
        Unsupported
    }
}