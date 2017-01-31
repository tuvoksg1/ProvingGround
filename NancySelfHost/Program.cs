using System;
using Microsoft.Owin.Hosting;
using Nancy.Hosting.Self;
using NancySelfHost.Configuration;

namespace NancySelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            const string url = "https://localhost:44388";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Running on {0}", url);
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
}
