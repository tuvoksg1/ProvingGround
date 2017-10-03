using System;

namespace Messenger.Console.Models
{
    class PledgeRun
    {
        public string RecordId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TenantCode { get; set; }
        public string ApplicationSource { get; set; }
        public string Content { get; set; }
        public int RecordsProcessed { get; set; }
        public int TotalPass { get; set; }
        public int TotalFail { get; set; }
        public string FileName { get; set; }
        public string JobPostId { get; set; }
        public Message Message { get; set; }
    }
}
