namespace RedisCache
{
    public class JobResult
    {
        public int Id { get; set; }
        public bool IsPromoted { get; set; }
        public bool IsHighlighted { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return IsHighlighted ? $"{Title} - Promoted Job" : IsPromoted ? $"{Title}*" : Title;
        }
    }
}
