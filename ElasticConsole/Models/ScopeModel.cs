using System.Collections.Generic;

namespace ElasticConsole.Models
{
    public class ScopeModel
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public List<string> Rights { get; set; }
    }
}
