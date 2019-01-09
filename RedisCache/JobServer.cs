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
            var standardResults = GetSearchJobs(page, promoJobs.Count).Take(PageSize);
            
            return promoJobs.Union(standardResults, _comparer).ToList();
        }

        private static List<JobResult> GetSearchJobs(int page, int promoCount)
        {
            var skip = (page - 1) * PageSize;

            //if (page > 1) skip -= promoCount;

            return _database.Skip(skip).Take(PageSize + PromotionsPerPage).ToList();
        }

        private List<JobResult> GetPromotedJobs(string sessionId, int page)
        {
            var key = $"promoted_jobs_{sessionId}";
            var cachedJobs = _cache.Database.Get<CacheList>(key) ?? new CacheList();

            if (cachedJobs.Count >= page) return cachedJobs.Single(item => item.Page == page).PromotedJobs;
            if (cachedJobs.Count >= MaxPromotedPages) return new List<JobResult>();

            var availablePromotions = GetPromotedJobs().Except(cachedJobs.All()).ToList();
            var chosePromotions = GetRandomPromotions(availablePromotions, PromotionsPerPage);

            chosePromotions.ForEach(item => item.IsHighlighted = true);

            cachedJobs.Add(new CacheItem
            {
                Page = page,
                PromotedJobs = chosePromotions
            });

            _cache.Database.Set(key, cachedJobs, TimeSpan.FromMinutes(TTL));

            return chosePromotions;
        }

        private List<JobResult> GetPromotedJobs()
        {
            return _database.Where(job => job.IsPromoted).ToList();
        }

        private List<JobResult> GetRandomPromotions(List<JobResult> promotedJobs, int size)
        {
            if(promotedJobs.Count <= size) return promotedJobs;

            var hashSet = new HashSet<int>();
            var selectedPromos = new List<JobResult>();

            while (hashSet.Count < size)
            {
                var index = _randomizer.Next(promotedJobs.Count);

                if (hashSet.Add(index))
                {
                    selectedPromos.Add(promotedJobs[index]);
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
