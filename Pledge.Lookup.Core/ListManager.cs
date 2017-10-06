using System.Collections.Generic;
using Pledge.Common.Interfaces.Lookup;
using Pledge.Common.Models.Lookup;

namespace Pledge.Lookup.Core
{
    public class ListManager : IListManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListManager"/> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public ListManager(IListSourceBuilder builder)
        {
            Builder = builder;
        }

        private IListSourceBuilder Builder { get; }

        /// <summary>
        /// Gets all the available lists for tenant.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<List> GetLists(string tenantId)
        {
            var availableLists = new List<List>();

            var providers = Builder.CreateProviders();

            foreach (var provider in providers)
            {
                availableLists.AddRange(provider.GetLists(tenantId));
            }

            return availableLists;
        }

        /// <summary>
        /// Gets the list with the specified name.
        /// </summary>
        /// <param name="listId">The id of the list.</param>
        /// <param name="name">The name of the list.</param>
        /// <param name="type">The list type.</param>
        /// <param name="tenantId">The tenant id.</param>
        /// <returns></returns>
        public List<string[]> GetList(string listId, string name, ListType type, string tenantId)
        {
            var provider = Builder.CreateProvider(type);

            return provider?.GetList(listId, name, tenantId);
        }

        /// <summary>
        /// Get the id of the list from the supplied name.
        /// </summary>
        /// <param name="name">The name of the list.</param>
        /// <param name="type">The list type.</param>
        /// <param name="tenantId">The tenant id.</param>
        /// <returns></returns>
        public string GetListId(string name, ListType type, string tenantId)
        {
            var provider = Builder.CreateProvider(type);

            return provider?.GetListId(name, tenantId);
        }

        /// <summary>
        /// Saves the list detail.
        /// </summary>
        /// <param name="list">Object containing all list detail.</param>
        public void SaveList(List list)
        {
            var provider = Builder.CreateProvider(list.Type);

            provider?.SaveList(list);
        }

        /// <summary>
        /// Deletes the list.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="type">The type.</param>
        /// <param name="tenantId">The tenant id.</param>
        public void DeleteList(string listId, ListType type, string tenantId)
        {
            var provider = Builder.CreateProvider(type);

            provider?.DeleteList(listId, tenantId);
        }
    }
}
