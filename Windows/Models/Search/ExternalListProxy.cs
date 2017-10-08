using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Pledge.Common.Exceptions;
using Pledge.Common.Interfaces;
using Pledge.Common.Interfaces.Lookup;
using Pledge.Common.Models;
using Pledge.Common.Models.Lookup;
using Pledge.Common.Operands;
using Pledge.Lookup.Core.IO;

namespace Windows.Models.Search
{
    /// <summary>
    /// Proxy class used to get rawList data from List Service
    /// </summary>
    public class ExternalListProxy : IListProxy
    {
        private const int _singleColumnValueField = 0;
        private const int _minRowSize = 1;

        /// <summary>
        /// The raw list cache (list of a list of strings) - could be single column or multiple
        /// </summary>
        protected readonly Dictionary<string, List<string[]>> RawListCache = new Dictionary<string, List<string[]>>();
        private readonly Dictionary<string, HashSet<IOperand>> _singleColumnListCache = new Dictionary<string, HashSet<IOperand>>();
        private readonly Dictionary<string, IReadOnlyList<IReadOnlyList<IOperand>>> _multiColumnListCache = new Dictionary<string, IReadOnlyList<IReadOnlyList<IOperand>>>();

        /// <summary>
        /// Creates an instance of the proxy
        /// </summary>
        public ExternalListProxy()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private static bool IsValidUri(string uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                return false;
            Uri tmp;
            if (!Uri.TryCreate(uri, UriKind.Absolute, out tmp))
                return false;
            return tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps;
        }

        /// <summary>
        /// Get single column list.
        /// </summary>
        /// <param name="name">This is the name of the rawList</param>
        /// <param name="listId">This is the id of the rawList</param>
        /// <param name="listType">This is the type of the rawList</param>
        /// <param name="tenantId">This is the tenant identifier</param>
        /// <returns></returns>
        public HashSet<IOperand> GetList(string listId, string name, ListType listType, string tenantId)
        {
            if (!IsInSingleColumnListCache(listId))
                _singleColumnListCache.Add(listId, ConvertToSingleColumnList(GetRawList(listId, name, listType, tenantId)));

            return _singleColumnListCache[listId];
        }

        private bool IsInSingleColumnListCache(string listId)
        {
            return _singleColumnListCache.ContainsKey(listId);
        }

        /// <summary>
        /// Get multi column list.
        /// </summary>
        /// <param name="listId">This is the id of the rawList</param>
        /// <param name="name">This is the name of the rawList</param>
        /// <param name="listType">This is the type of the rawList</param>
        /// <param name="tenantId">This is the tenant identifier</param>
        /// <returns></returns>
        public IReadOnlyList<IReadOnlyList<IOperand>> GetMultiColumnList(string listId, string name, ListType listType, string tenantId)
        {
            if (!IsInMultiColumnListCache(listId))
                _multiColumnListCache.Add(listId, ConvertToMultiColumnList(GetRawList(listId, name, listType, tenantId)));

            return _multiColumnListCache[listId];
        }

        /// <summary>
        /// Get multi column list of operands.
        /// </summary>
        /// <param name="listId">This is the id of the rawList</param>
        /// <param name="multiColumnList">This items to convert</param>
        /// <returns></returns>
        public IReadOnlyList<IReadOnlyList<IOperand>> GetMultiColumnList(string listId, List<string[]> multiColumnList)
        {
            if (!IsInMultiColumnListCache(listId))
                _multiColumnListCache.Add(listId, ConvertToMultiColumnList(multiColumnList));

            return _multiColumnListCache[listId];
        }

        private bool IsInMultiColumnListCache(string name)
        {
            return _multiColumnListCache.ContainsKey(name);
        }

        private static IReadOnlyList<IReadOnlyList<IOperand>> ConvertToMultiColumnList(List<string[]> rawList)
        {
            return rawList?.FindAll(WithMinRowSize).ConvertAll(ToMultiConstantOperands);
        }

        private static IReadOnlyList<IOperand> ToMultiConstantOperands(string[] input)
        {
            var operandList = new List<IOperand>();
            if (input != null)
                operandList.AddRange(input.Select(CreateConstantOperand));
            return operandList;
        }

        private List<string[]> GetRawList(string listId, string name, ListType listType, string tenantId)
        {
            if (!IsListInCache(listId))
                PutListInCache(listId, name, listType, tenantId);

            return RawListCache[listId];
        }

        /// <summary>
        /// Puts the list in cache.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="listId">The name.</param>
        /// <param name="listType">Type of the list.</param>
        /// <param name="tenantId">Tenant identifier</param>
        protected virtual void PutListInCache(string listId, string name, ListType listType, string tenantId)
        {
            RawListCache.Add(listId, PerformLookup(listId, name, tenantId));
        }

        private static List<string[]> PerformLookup(string listId, string listName, string tenantId)
        {
            var listProvider = new FileListProvider();
            return listProvider.GetList(listId, listName, tenantId);
        }

        private static StringContent CreateRequestBody(List listParameters)
        {
            var content = new StringContent(JsonConvert.SerializeObject(listParameters),
                Encoding.UTF8, "application/json");
            return content;
        }

        private bool IsListInCache(string name)
        {
            return RawListCache.ContainsKey(name);
        }

        private static HashSet<IOperand> ConvertToSingleColumnList(List<string[]> rawList)
        {
            return rawList == null ? 
                new HashSet<IOperand>() : 
                new HashSet<IOperand>(rawList.FindAll(WithMinRowSize).ConvertAll(ToConstantOperand));
        }

        private static IOperand ToConstantOperand(string[] row)
        {
            var value = row[_singleColumnValueField];
            return CreateConstantOperand(value);
        }

        private static IOperand CreateConstantOperand(string value)
        {
            return new ConstantOperand(value);
        }

        private static bool WithMinRowSize(string[] row)
        {
            return row?.Length >= _minRowSize;
        }

        /// <summary>
        /// Get the rawList.
        /// </summary>
        public virtual IEnumerable<List> GetAllLists(string tenantId)
        {
            return new List<List>();
        }

        /// <summary>
        /// Get the id of the list from the supplied name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="listType">Type of the list.</param>
        /// <param name="tenantId">Tenant identifier</param>
        public string GetListId(string name, ListType listType, string tenantId)
        {
            const string listEndpoint = "list/listId";
            var listParameters = new List { Type = listType, Name = name, TenantId = tenantId };
            var requestBody = CreateRequestBody(listParameters);
            var listId = string.Empty;

            return listId;
        }

        /// <summary>
        /// Saves list meta data and list items
        /// </summary>
        /// <param name="listParameters"></param>
        /// <returns></returns>
        public bool SaveList(List listParameters)
        {
            const string listEndpoint = "list/save";
            var requestBody = CreateRequestBody(listParameters);
            return true;
        }

        /// <summary>
        /// Deletes the list.
        /// </summary>
        /// <param name="listId">The list identifier.</param>
        /// <param name="listType">Type of the list.</param>
        /// <param name="tenantId"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool DeleteList(string listId, ListType listType, string tenantId)
        {
            const string listEndpoint = "list/remove";
            var listParameters = new List { Type = listType, ListId = listId, TenantId = tenantId };
            var requestBody = CreateRequestBody(listParameters);
            return true;
        }
    }

    /// <summary>
    /// NotFoundException 
    /// </summary>
    internal class NotFoundException : Exception
    {
    }
}
