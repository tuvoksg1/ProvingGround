using System;
using Nest;

namespace Messenger
{
    [ElasticsearchType(Name = "message")]
    public class Message
    {
        [String(Name = "id", Analyzer = "keyword")]
        public string Id { get; set; }
        [Date(Name = "eventDate", Index = NonStringIndexOption.NotAnalyzed, Format = "dateOptionalTime")]
        public DateTime EventDate { get; set; }
        [String(Name = "tenantCode", Index = FieldIndexOption.Analyzed)]
        public string TenantCode { get; set; }
        [String(Name = "applicationSource", Index = FieldIndexOption.Analyzed)]
        public string ApplicationSource { get; set; }
        [String(Name = "content", Index = FieldIndexOption.NotAnalyzed)]
        public string Content { get; set; }
    }
}
