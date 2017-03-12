using Nest;

namespace Messenger.Console.Models
{
    [ElasticsearchType(Name = "invoiceMessage")]
    public class InvoiceMessage : Message
    {
        [Number(Name = "recordsProcessed", Index = NonStringIndexOption.NotAnalyzed)]
        public int RecordsProcessed { get; set; }

        [String(Name = "country", Index = FieldIndexOption.Analyzed)]
        public string Country { get; set; }

        [String(Name = "dealer", Index = FieldIndexOption.Analyzed)]
        public string Dealer { get; set; }
    }
}
