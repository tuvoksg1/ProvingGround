using Nest;

namespace Messenger.Console.Models
{
    [ElasticsearchType(Name = "invoiceMessage")]
    public class InvoiceMessage : Message
    {
        [Number(Name = "recordsProcessed", Index = true)]
        public int RecordsProcessed { get; set; }

        [Keyword(Name = "country", Index = true)]
        public string Country { get; set; }

        [Keyword(Name = "dealer", Index = true)]
        public string Dealer { get; set; }
    }
}
