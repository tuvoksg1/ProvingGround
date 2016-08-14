using System.Collections.Generic;
using Nancy.ViewEngines.Razor;

namespace NancySelfHost.Configuration
{
    public class RazorConfig : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            yield return "System.Web.Mvc";
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            yield return "System.Web.Mvc";
        }

        public bool AutoIncludeModelNamespace => true;
    }
}
