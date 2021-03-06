﻿using System.Collections.Generic;

namespace ElasticConsole.Models
{
    public class TenantModel
    {
        public TenantModel()
        {
            Claims = new List<ClaimModel>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Claim { get; set; }
        public int UserCount { get; set; }
        public bool IsActive { get; set; }
        public List<ClaimModel> Claims { get; set; }
    }
}
