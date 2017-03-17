using System;
using Nest;

namespace Messenger.Console.Models
{
    [ElasticsearchType(Name = "incidenceMessage")]
    public class IncidenceMessage : Message
    {
        [Date(Name = "startDate", Index = true, Format = "dateOptionalTime")]
        public DateTime StartDate { get; set; }

        [Date(Name = "endDate", Index = true, Format = "dateOptionalTime")]
        public DateTime EndDate { get; set; }

        [Keyword(Name = "machineName", Index = true)]
        public string MachineName { get; set; }
    }
}
