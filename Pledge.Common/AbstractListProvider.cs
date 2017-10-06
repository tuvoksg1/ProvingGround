using System;
using System.Collections.Generic;
using System.Linq;
using Pledge.Common.Interfaces.Lookup;
using Pledge.Common.Models.Lookup;

namespace Pledge.Common
{
    /// <summary>
    /// Abstract implemetation of the IListProvider to provide the GetMultiColumnList-Method.
    /// </summary>
    public abstract class AbstractListProvider : IListProvider
    {
        /// <summary>
        /// 
        /// </summary>
        protected static string[] ColumnSeparators { get; set; } = {"|"};

        /// <summary>
        /// Gets the lists for tenant.
        /// </summary>
        /// <param name="tenantId">The tenant id.</param>
        /// <returns></returns>
        public abstract IEnumerable<List> GetLists(string tenantId);

        /// <summary>
        /// Get Single Column raw List.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="name">The list name.</param>
        /// <param name="tenantId">The tenant id.</param>
        /// <returns></returns>
        public abstract List<string> GetSingleColumnList(string listId, string name, string tenantId);

        /// <summary>
        /// Get the Type.
        /// </summary>
        public abstract ListType Type { get; }

        /// <summary>
        /// Deletes the list.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="tenantId">The tenant id.</param>
        public abstract void DeleteList(string listId, string tenantId);

        /// <summary>
        /// Get single Column List.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="name">The list name.</param>
        /// <param name="tenantId">The tenant id.</param>
        /// <returns></returns>
        public List<string[]> GetList(string listId, string name, string tenantId)
        {
            var listContent = GetSingleColumnList(listId, name, tenantId);
            var multiColumnsList = listContent == null ? null : ConvertToMultiColumnList(listContent);
            return multiColumnsList;
        }

        /// <summary>
        /// Get the id of the list from the supplied name.
        /// </summary>
        /// <param name="name">The list name.</param>
        /// <param name="tenantId">The tenant id.</param>
        /// <returns></returns>
        public abstract string GetListId(string name, string tenantId);

        /// <summary>
        /// Saves the list detail.
        /// </summary>
        /// <param name="list">Object containing all list detail.</param>
        public abstract void SaveList(List list);

        /// <summary>
        /// Convert To Multi Column List.
        /// </summary>
        /// <param name="listContent">Full contents of the list.</param>
        /// <returns></returns>
        public static List<string[]> ConvertToMultiColumnList(List<string> listContent)
        {
            return listContent != null ? CreateMultiColumnList(listContent) : null;
        }

        private static List<string[]> CreateMultiColumnList(IEnumerable<string> listContent)
        {
            var multiColumnsList = new List<string[]>();
            FilloutMultiColumnList(listContent, multiColumnsList);
            return multiColumnsList;
        }

        private static void FilloutMultiColumnList(IEnumerable<string> listContent, List<string[]> multiColumnsList)
        {
            multiColumnsList.AddRange(
                from line in listContent
                where !string.IsNullOrWhiteSpace(line)
                select line.Split(ColumnSeparators, StringSplitOptions.None)
                );
        }
    }
}
