using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Pledge.Common.Interfaces.Lookup;
using Pledge.Common.Models.Lookup;

namespace Pledge.Lookup.Core
{
    public class ListSourceBuilder : IListSourceBuilder
    {
        public IEnumerable<IListProvider> CreateProviders()
        {
            var providers = new List<IListProvider>();

            var matrix =
                ConfigurationManager.GetSection(ListGlobal.ProviderMatrixSection) as ProviderMatrix;

            if (matrix == null) return providers;

            foreach (var provider in matrix.Providers)
            {
                var providerType = Type.GetType(provider.Namespace);

                if (providerType == null) continue;
                var component = Activator.CreateInstance(providerType) as IListProvider;
                providers.Add(component);
            }

            return providers;
        }

        public IListProvider CreateProvider(ListType type)
        {
            var matrix =
                ConfigurationManager.GetSection(ListGlobal.ProviderMatrixSection) as ProviderMatrix;

            if (matrix == null) return null;

            var listProvider = matrix.Providers.FirstOrDefault(arg => arg.Type == type);

            if (listProvider == null) return null;

            var providerType = Type.GetType(listProvider.Namespace);

            if (providerType == null) return null;

            var provider = Activator.CreateInstance(providerType) as IListProvider;

            return provider;
        }
    }
}
