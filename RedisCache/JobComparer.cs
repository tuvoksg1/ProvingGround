using System.Collections.Generic;

namespace RedisCache
{
    public class JobComparer : IEqualityComparer<JobResult>
    {
        public bool Equals(JobResult first, JobResult second)
        {
            if (first == null && second == null)
                return true;

             if (first == null || second == null)
                return false;

            return first.Id == second.Id;
        }

        public int GetHashCode(JobResult job)
        {
            return job.Id;
        }
    }
}
