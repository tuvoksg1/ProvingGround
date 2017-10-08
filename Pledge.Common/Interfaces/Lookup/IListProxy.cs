using System.Collections.Generic;
using Pledge.Common.Models.Lookup;
using Pledge.Common.Operands;

namespace Pledge.Common.Interfaces.Lookup
{
    /// <summary>
    /// 
    /// </summary>
    public interface IListProxy
    {
        /// <summary>
        /// Get the content of the list.
        /// </summary>
        /// <param name="listId">This is the id of the list</param>
        /// <param name="name">This is the name of the list</param>
        /// <param name="listType">This is the type of the list</param>
        /// <param name="tenantId">This is the tenant identifier</param>
        /// <returns></returns>
        OperandLookup GetList(string listId, string name, ListType listType, string tenantId);

        /// <summary>
        /// Get the content of the list.
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="name"></param>
        /// <param name="listType"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        IReadOnlyList<OperandLookup> GetMultiColumnList(string listId, string name, ListType listType, string tenantId);

        /// <summary>
        /// Get multi column list of operands.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="multiColumnList">This items to convert</param>
        /// <returns></returns>        
        IReadOnlyList<OperandLookup> GetMultiColumnList(string name, List<string[]> multiColumnList);

        /// <summary>
        /// Get the list of all external lists.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        IEnumerable<List> GetAllLists(string tenantId);

        /// <summary>
        /// Get the id of the list from the supplied name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="listType"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        string GetListId(string name, ListType listType, string tenantId);

        /// <summary>
        /// Saves list meta data and list items
        /// </summary>
        /// <param name="listParameters"></param>
        /// <returns></returns>
        bool SaveList(List listParameters);

        /// <summary>
        /// Deletes the list.
        /// </summary>
        /// <param name="listId">The list identifier.</param>
        /// <param name="listType">Type of the list.</param>
        /// <param name="tenantId"></param>
        bool DeleteList(string listId, ListType listType, string tenantId);
    }
}
