using Nest;

namespace Messenger.Console.Models
{
    [ElasticsearchType(Name = "traceMessage")]
    public class TraceMessage : Message
    {
        [Number(Name = "totalPass", Index = false)]
        public int TotalPass { get; set; }

        [Number(Name = "totalFail", Index = false)]
        public int TotalFail { get; set; }

        [Keyword(Name = "fileName", Index = false)]
        public string FileName { get; set; }

        [Keyword(Name = "jobId", Index = false)]
        public string JobId { get; set; }
    }
}
