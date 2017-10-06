using System.Collections.Generic;
using Pledge.Common.Models.Lookup;

namespace Pledge.Common.Interfaces.Lookup
{
    /// <summary>
    /// Represents a type capable of consolidating multiple list sources
    /// </summary>
    public interface IListManager
    {
        /// <summary>
        /// Gets all the available lists for tenant.
        /// </summary>
        /// <param name="tenantId">The tenant id.</param>
        /// <returns></returns>
        IEnumerable<List> GetLists(string tenantId);

        /// <summary>
        /// Gets the list with the specified name.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="name">The name of the list.</param>
        /// <param name="type">The list type.</param>
        /// <param name="tenantId">The tenant id.</param>
        /// <returns></returns>
        List<string[]> GetList(string listId, string name, ListType type, string tenantId);

        /// <summary>
        /// Get the id of the list from the supplied name.
        /// </summary>
        /// <param name="name">The name of the list.</param>
        /// <param name="type">The type.</param>
        /// <param name="tenantId">The tenant id.</param>
        /// <returns></returns>
        string GetListId(string name, ListType type, string tenantId);

        /// <summary>
        /// Saves the list detail.
        /// </summary>
        /// <param name="list">Object containing all list detail.</param>
        void SaveList(List list);

        /// <summary>
        /// Deletes the list.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="type">The type.</param>
        /// <param name="tenantId">The tenant id.</param>
        void DeleteList(string listId, ListType type, string tenantId);
    }
}
