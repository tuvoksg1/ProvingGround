using System;

namespace ElasticConsole.Models
{
    public class ClaimModel
    {
        public Guid Id { get; set; }
        public Guid Owner { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
