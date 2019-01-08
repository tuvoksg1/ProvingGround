using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisCache
{
    public class JobServer
    {
        private static readonly string _jobsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RegularJobs.json");
        private static JobCache _cache;
        private static List<JobResult> _database;
        private static readonly Random _randomizer = new Random();
        private static readonly JobComparer _comparer = new JobComparer();

        public JobServer()
        {
            Initialise();
        }

        public List<JobResult> GetJobs(string sessionId, int page)
        {
            var standardResults = GetSearchJobs(page);
            var promoJobs = GetPromotedJobs(sessionId);
            return promoJobs.Union(standardResults, _comparer).Take(10).ToList();
        }

        private static List<JobResult> GetSearchJobs(int page)
        {
            var skip = (page - 1) * 10;

            return _database.Skip(skip).Take(15).ToList();
        }

        private List<JobResult> GetPromotedJobs(string sessionId)
        {
            var cachedJobs = _cache.Database.Get<CacheItem>($"promoted_jobs_{sessionId}") ?? new CacheItem();
            var promotedJobs = GetPromotedJobs().Except(cachedJobs.PromotedJobs).ToList();

            return GetRandomPromotions(promotedJobs, 2);
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
