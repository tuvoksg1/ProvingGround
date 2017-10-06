using System.ComponentModel;

namespace Pledge.Common.Models.Lookup
{
    /// <summary>
    /// Indicates the source of a list
    /// </summary>
    public enum ListType
    {
        /// <summary>
        /// A list obtained from the file system
        /// </summary>
        [Description("File System")]
        FileSystem,
        /// <summary>
        /// A list obtained from the database
        /// </summary>
        [Description("Database")]
        Database
    }
}
