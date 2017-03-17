using System;

namespace Messenger.Console.Models
{
    class PledgeRun
    {
        //[Keyword(Name = "id")]
        public string RunId { get; set; }
        //[Date(Name = "startDate", Index = true, Format = "dateOptionalTime")]
        public DateTime StartDate { get; set; }
        //[Date(Name = "endDate", Index = true, Format = "dateOptionalTime")]
        public DateTime EndDate { get; set; }
        //[Keyword(Name = "tenantCode", Index = true)]
        public string TenantCode { get; set; }
        //[Keyword(Name = "applicationSource", Index = true)]
        public string ApplicationSource { get; set; }
        //[Text(Name = "content", Index = true)]
        public string Content { get; set; }
        //[Number(Name = "recordsProcessed", Index = true)]
        public int RecordsProcessed { get; set; }
        //[Keyword(Name = "country", Index = true)]
        //[Number(Name = "totalPass", Index = false)]
        public int TotalPass { get; set; }
        //[Number(Name = "totalFail", Index = false)]
        public int TotalFail { get; set; }
        //[Keyword(Name = "fileName", Index = false)]
        public string FileName { get; set; }
        //[Keyword(Name = "jobId", Index = false)]
        public string JobId { get; set; }
    }
}
