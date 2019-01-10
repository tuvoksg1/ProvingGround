using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RedisCache
{
    public class JobServer
    {
        private static readonly string _jobsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RegularJobs.json");
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
            var standardResults = GetSearchJobs(page, promoJobs.Count).Take(PageSize - promoJobs.Count);
            
            return promoJobs.Union(standardResults, _comparer).ToList();
        }

        private static List<JobResult> GetSearchJobs(int page, int promoCount)
        {
            var skip = (page - 1) * PageSize;

            if (page > 1) skip -= promoCount * (page - 1);

            return _database.Skip(skip).Take(PageSize + PromotionsPerPage).ToList();
        }

        private List<JobResult> GetPromotedJobs(string sessionId, int page)
        {
            if (page > MaxPromotedPages) return new List<JobResult>();

            var key = $"promoted_jobs_{sessionId}";
            var cacheList = _cache.Database.Get<CacheList>(key) ?? new CacheList();

            if (cacheList.HasPage(page)) return cacheList.Fetch(page).PromotedJobs;

            var availablePromotions = GetAllPromotedJobs().Except(cacheList.All(), _comparer).ToList();
            var chosePromotions = GetRandomPromotions(availablePromotions, PromotionsPerPage);

            cacheList.Add(new CacheItem
            {
                Page = page,
                PromotedJobs = chosePromotions
            });

            _cache.Database.Set(key, cacheList, TimeSpan.FromMinutes(TTL));

            return chosePromotions;
        }

        private List<JobResult> GetAllPromotedJobs()
        {
            return _database.Where(job => job.IsPromoted).ToList();
        }

        private List<JobResult> GetRandomPromotions(List<JobResult> promotedJobs, int size)
        {
            if(promotedJobs.Count <= size) return promotedJobs.Select(promo => new JobResult
            {
                Id = promo.Id,
                Title = promo.Title,
                IsPromoted = promo.IsPromoted,
                IsHighlighted = true
            }).ToList();

            var hashSet = new HashSet<int>();
            var selectedPromos = new List<JobResult>();

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

        private void Initialise()
        {
            if (File.Exists(_jobsFile))
            {
                var jsonText = File.ReadAllText(_jobsFile);

                if (!string.IsNullOrWhiteSpace(jsonText))
                {
                    _database = JsonConvert.DeserializeObject<List<JobResult>>(jsonText, JsonSettings);
                }
            }

            _cache = new JobCache("localhost", 6379, 30);
        }

        private static JsonSerializerSettings JsonSettings => new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            Formatting = Formatting.Indented,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Include
        };
    }
}
