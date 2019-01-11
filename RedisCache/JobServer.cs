using System;
using System.Collections.Generic;
using System.Linq;

namespace RedisCache
{
    public class JobServer
    {
        private static JobCache _cache;
        private static List<JobResult> _database;
        private static readonly Random _randomizer = new Random();
        private static readonly JobComparer _comparer = new JobComparer();
        private const int MaxPromotedPages = 3;
        private const int PromotionsPerPage = 2;
        private const int PageSize = 10;
        private const int TTL = 5;

        public JobServer()
        {
            Initialise();
        }

        public List<JobResult> GetJobs(string sessionId, int page)
        {
            var promoJobs = GetPromotedJobs(sessionId, page);
            var standardResults = GetSearchJobs(page, promoJobs.Count()).Take(PageSize);
            
            return promoJobs.Union(standardResults, _comparer).ToList();
        }

        private static List<JobResult> GetSearchJobs(int page, int promoCount)
        {
            var skip = (page - 1) * PageSize;

            //pad with the number of promos per page to ensure we never return fewer items than page size.
            //This can happen if there are items within this page that will also be promoted on this page
            return _database.Skip(skip).Take(PageSize + PromotionsPerPage).ToList();
        }

        private List<JobResult> GetPromotedJobs(string sessionId, int page)
        {
            //if promoted jobs are turned off 
            //or we've exceeded the page at which we show promoted jobs
            if (PromotionsPerPage < 1 || page > MaxPromotedPages) return new List<JobResult>();

            var key = $"promoted_jobs_{sessionId}";
            var cacheList = _cache.Database.Get<CacheList>(key) ?? new CacheList();

            if (cacheList.HasPage(page)) return cacheList.Fetch(page).PromotedJobs;

            //if there is nothing in the cache for this user tah this page
            //retrieve a list of avialable promoted jobs not including those that may have been shown other pages
            var availablePromotions = GetAllPromotedJobs().Except(cacheList.All(), _comparer).ToList();
            var chosePromotions = GetRandomPromotions(availablePromotions, CalculatePromoCount(page));

            cacheList.Add(new CacheItem
            {
                Page = page,
                PromotedJobs = chosePromotions
            });

            //update the cache for this user at this page
            _cache.Database.Set(key, cacheList, TimeSpan.FromMinutes(TTL));

            return chosePromotions;
        }

        private static List<JobResult> GetAllPromotedJobs()
        {
            return _database.Where(job => job.IsPromoted).ToList();
        }

        private List<JobResult> GetRandomPromotions(List<JobResult> promotedJobs, int size)
        {
            if (promotedJobs.Count <= size)
            {
                //return everything
                return promotedJobs.Select(promo => new JobResult
                {
                    Id = promo.Id,
                    Title = promo.Title,
                    IsPromoted = promo.IsPromoted,
                    IsHighlighted = true
                }).ToList();
            }

            var hashSet = new HashSet<int>();
            var selectedPromos = new List<JobResult>();

            //pick randomly from the selection
            while (hashSet.Count < size)
            {
                var index = _randomizer.Next(promotedJobs.Count);

                if (hashSet.Add(index))
                {
                    var promo = promotedJobs[index];
                    selectedPromos.Add(new JobResult
                    {
                        Id = promo.Id,
                        Title = promo.Title,
                        IsPromoted = promo.IsPromoted,
                        IsHighlighted = true
                    });
                }
            }

            return selectedPromos;
        }

        private static int CalculatePromoCount(int page)
        {
            //if promoted jobs are turned off 
            //or we've exceeded the page at which we show promoted jobs
            if (PromotionsPerPage < 1 || page > MaxPromotedPages) return 0;

            var total = GetAllPromotedJobs().Count;

            var quotient = Math.DivRem(total, PromotionsPerPage, out var remainder);

            //if there aren't enough promoted jobs to fill the first x pages
            if (quotient < page - 1) return 0;

            return quotient < page ? remainder : PromotionsPerPage;
        }

        private static void Initialise()
        {
            _database = JobDatabase.Initialise();
            _cache = new JobCache("localhost", 6379, 30);
        }
    }
}
