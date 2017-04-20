using System;
using Messenger.Console.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Messenger.Console
{
    class JsonBuilder
    {
        public static void Build()
        {
            var trace = new TraceMessage
            {
                Id = Guid.NewGuid().ToString(),
                EventDate = DateTime.UtcNow,
                TenantCode = "MaritzCX",
                ApplicationSource = "Pledge",
                Content = "Trace",
                TotalFail = 3,
                TotalPass = 3,
                FileName = "Trace file.txt",
                JobId = Guid.NewGuid().ToString()
            };

            var incidence = new IncidenceMessage
            {
                Id = Guid.NewGuid().ToString(),
                EventDate = DateTime.Now,
                TenantCode = "MaritzCX",
                ApplicationSource = "Pledge",
                Content = $"Incidence",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                MachineName = "incidence Machine"
            };

            var invoice = new InvoiceMessage
            {
                Id = Guid.NewGuid().ToString(),
                EventDate = DateTime.UtcNow,
                TenantCode = "MaritzCX",
                ApplicationSource = "Pledge",
                Content = $"Invoice",
                RecordsProcessed = 343,
                Country = "Japan",
                Dealer = "Nissan"
            };

            var traceContent = Build(trace, "cx_trace", "trace");
            var incidenceContent = Build(incidence, "cx_incidence", "incidence");
            var invoiceContent = Build(invoice, "cx_invoice", "invoice");

            System.Console.WriteLine("Trace JSON");
            System.Console.WriteLine(traceContent);
            System.Console.WriteLine();
            System.Console.WriteLine("Incidence JSON");
            System.Console.WriteLine(incidenceContent);
            System.Console.WriteLine();
            System.Console.WriteLine("Invoice JSON");
            System.Console.WriteLine(invoiceContent);
        }

        private static string Build<T>(T log, string index, string type) where T : Message
        {
            var record = new JObject
            {
                {"MessageId", log.Id},
                {"ClientName", "Pledge"},
                {"TargetIndex", index},
                {"TargetType", type},
                {
                    "Payload", JObject.FromObject(log)
                }
            };

            return record.ToString(Formatting.Indented);
        }
    }
}
