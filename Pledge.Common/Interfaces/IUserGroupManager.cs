using System;
using System.Collections.Generic;
using Pledge.Common.Models.Security;

namespace Pledge.Common.Interfaces
{
    /// <summary>
    /// A component capable of retrieving and processing user group membership data
    /// </summary>
    public interface IUserGroupManager
    {
        /// <summary>
        /// Adds the member to the specified user group.
        /// </summary>
        /// <param name="groupId">The group identifier.</param>
        /// <param name="user">The user.</param>
        /// <param name="tenantId"></param>
        void AddMember(Guid groupId, string user, Guid tenantId);

        /// <summary>
        /// Removes the members from the specified user group.
        /// </summary>
        /// <param name="groupId">The group identifier.</param>
        /// <param name="users">The users.</param>
        void RemoveMembers(Guid groupId, List<Guid> users);

        /// <summary>
        /// Gets the group members.
        /// </summary>
        /// <param name="groupId">The group identifier.</param>
        List<GroupMember> GetGroupMembers(Guid groupId);

        /// <summary>
        /// Creates a user group to be managed by the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        void CreateUserGroup(string user);

        /// <summary>
        /// Gets the groups the specified user belongs to.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="tenantId">Organisation of the user.</param>
        List<Guid> GetGroups(Guid userId, Guid tenantId);

        /// <summary>
        /// Gets the user's default group.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="tenantId">Organisation of the user.</param>
        Guid GetUserGroup(Guid userId,Guid tenantId);
    }
}
