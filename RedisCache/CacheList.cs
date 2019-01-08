using System.Collections.Generic;
using System.Linq;

namespace RedisCache
{
    public class CacheList : List<CacheItem>
    {
        public IEnumerable<JobResult> All() => this.SelectMany(job => job.PromotedJobs);
    }
}
