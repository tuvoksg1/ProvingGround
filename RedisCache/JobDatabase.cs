using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace RedisCache
{
    public class JobDatabase
    {
        private static readonly string _jobsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RegularJobs.json");

        public static List<JobResult> Initialise()
        {
            if (File.Exists(_jobsFile))
            {
                var jsonText = File.ReadAllText(_jobsFile);

                if (!string.IsNullOrWhiteSpace(jsonText))
                {
                    return JsonConvert.DeserializeObject<List<JobResult>>(jsonText, JsonSettings);
                }
            }

            return new List<JobResult>();
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
