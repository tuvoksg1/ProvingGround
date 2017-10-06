using System;

namespace Pledge.Common.Models.Security
{
    /// <summary>
    /// A member of a user group
    /// </summary>
    public class GroupMember
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string DisplayName { get; set; }
    }
}