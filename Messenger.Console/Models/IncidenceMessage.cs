using System;
using Nest;

namespace Messenger.Console.Models
{
    [ElasticsearchType(Name = "incidenceMessage")]
    public class IncidenceMessage : Message
    {
        [Date(Name = "startDate", Index = NonStringIndexOption.NotAnalyzed, Format = "dateOptionalTime")]
        public DateTime StartDate { get; set; }

        [Date(Name = "endDate", Index = NonStringIndexOption.NotAnalyzed, Format = "dateOptionalTime")]
        public DateTime EndDate { get; set; }

        [String(Name = "machineName", Index = FieldIndexOption.Analyzed)]
        public string MachineName { get; set; }
    }
}
