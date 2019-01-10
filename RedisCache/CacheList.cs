using System.Collections.Generic;
using System.Linq;

namespace RedisCache
{
    public class CacheList : List<CacheItem>
    {
        public IEnumerable<JobResult> All() => this.SelectMany(job => job.PromotedJobs);

        public bool HasPage(int page) => Exists(cache => cache.Page == page);

        public CacheItem Fetch(int page) => this.Single(cache => cache.Page == page);
    }
}
