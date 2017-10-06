namespace Pledge.Common.Models.Remote
{
    /// <summary>
    /// A list of possible handlers
    /// </summary>
    public enum HandlerType
    {
        /// <summary>
        /// File System
        /// </summary>
        FileSystem = 0,
        /// <summary>
        /// FTP
        /// </summary>
        Ftp = 1,
        /// <summary>
        /// SMTP
        /// </summary>
        Smtp = 2,
        /// <summary>
        /// Web Service
        /// </summary>
        WebService = 3,
        /// <summary>
        /// CX Passport
        /// </summary>
        Passport = 4
    }
}
