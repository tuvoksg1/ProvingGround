using System;
using System.Threading.Tasks;

namespace Web
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Running job...");

#pragma warning disable 4014
            TestCaseManagement();
#pragma warning restore 4014

            Console.ReadLine();
        }

        private static async Task TestCaseManagement()
        {
            //var ingest = new CaseIngestWcf();
            var ingest = new CaseIngestHttp();

            await ingest.Start();
        }
    }
}
