namespace Pledge.Common.Models.Remote
{
    /// <summary>
    /// Represents information about a scheduled job and the tenant to which it belongs
    /// </summary>
    public class RemoteJobInfo
    {
        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        public string TenantId { get; set; }
        /// <summary>
        /// Gets or sets the tenant code.
        /// </summary>
        public string TenantCode { get; set; }
        /// <summary>
        /// Gets or sets the serialized content.
        /// </summary>
        public string Content { get; set; }
    }
}
