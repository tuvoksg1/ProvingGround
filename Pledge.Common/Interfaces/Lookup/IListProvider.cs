using System.Collections.Generic;
using Pledge.Common.Models.Lookup;

namespace Pledge.Common.Interfaces.Lookup
{
    /// <summary>
    /// Represents a type capable of handling a specific list type
    /// </summary>
    public interface IListProvider
    {
        /// <summary>
        /// Gets the lists for tenant.
        /// </summary>
        /// <param name="tenantId">The tenant id.</param>
        /// <returns></returns>
        IEnumerable<List> GetLists(string tenantId);

        /// <summary>
        /// Gets the list with the specified name.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="name">The list name.</param>
        /// <param name="tenantId">The tenant id.</param>
        /// <returns></returns>
        List<string[]> GetList(string listId, string name, string tenantId);

        /// <summary>
        /// Get the id of the list from the supplied name.
        /// </summary>
        /// <param name="name">The list name.</param>
        /// <param name="tenantId">The tenant id.</param>
        /// <returns></returns>
        string GetListId(string name, string tenantId);
        /// <summary>
        /// Gets the list with the specified name. Each line is unsplit.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="name">The list name.</param>
        /// <param name="tenantId">The tenant id.</param>
        /// <returns></returns>
        List<string> GetSingleColumnList(string listId, string name, string tenantId);

        /// <summary>
        /// Gets the type of lists provided by this type.
        /// </summary>
        ListType Type { get; }

        /// <summary>
        /// Saves the list detail.
        /// </summary>
        /// <param name="list">Object containing all list detail.</param>
        void SaveList(List list);

        /// <summary>
        /// Deletes the list.
        /// </summary>
        /// <param name="listId">The list identifier.</param>
        /// <param name="tenantId">The tenant identifier.</param>
        void DeleteList(string listId, string tenantId);
    }
}
