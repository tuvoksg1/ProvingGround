using System;
using Nest;

namespace Messenger
{
    [ElasticsearchType(Name = "message")]
    public class Message
    {
        [Keyword(Name = "id")]
        public string Id { get; set; }
        [Date(Name = "eventDate", Index = true, Format = "dateOptionalTime")]
        public DateTime EventDate { get; set; }
        [Keyword(Name = "tenantCode", Index = true)]
        public string TenantCode { get; set; }
        [Keyword(Name = "applicationSource", Index = true)]
        public string ApplicationSource { get; set; }
        [Text(Name = "content", Index = true)]
        public string Content { get; set; }
    }
}
