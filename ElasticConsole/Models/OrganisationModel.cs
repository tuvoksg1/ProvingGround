using System;

namespace ElasticConsole.Models
{
    public class OrganisationModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Claim { get; set; }
        public int UserCount { get; set; }
        public bool IsActive { get; set; }
    }
}
