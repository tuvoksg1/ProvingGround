using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisCache
{
    public class CacheItem
    {
        public CacheItem()
        {
            PromotedJobs = new List<JobResult>();
        }

        public int Page { get; set; }
        public List<JobResult> PromotedJobs { get; set; }
    }
}
