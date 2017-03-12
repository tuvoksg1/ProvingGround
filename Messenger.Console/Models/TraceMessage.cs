using Nest;

namespace Messenger.Console.Models
{
    [ElasticsearchType(Name = "traceMessage")]
    public class TraceMessage : Message
    {
        [Number(Name = "totalPass", Index = NonStringIndexOption.NotAnalyzed)]
        public int TotalPass { get; set; }

        [Number(Name = "totalFail", Index = NonStringIndexOption.NotAnalyzed)]
        public int TotalFail { get; set; }

        [String(Name = "fileName", Index = FieldIndexOption.NotAnalyzed)]
        public string FileName { get; set; }

        [String(Name = "jobId", Index = FieldIndexOption.Analyzed)]
        public string JobId { get; set; }
    }
}
