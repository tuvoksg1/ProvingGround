using System.Collections.Generic;
using Pledge.Common.Models.Lookup;

namespace Pledge.Common.Interfaces.Lookup
{
    /// <summary>
    /// A component capable of creating concrete list sources
    /// </summary>
    public interface IListSourceBuilder
    {
        /// <summary>
        /// Creates the provider.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IListProvider> CreateProviders();

        /// <summary>
        /// Creates the provider.
        /// </summary>
        /// <param name="type">The list type</param>
        /// <returns></returns>
        IListProvider CreateProvider(ListType type);
    }
}
