namespace RedisCache
{
    public class JobResult
    {
        public int Id { get; set; }
        public bool IsPromoted { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return IsPromoted ? $"{Title} - Promoted Job" : Title;
        }
    }
}
