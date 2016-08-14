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
            var url = "https://localhost:44388";

            var uri =
                new Uri(url);

            var config = new HostConfiguration
            {
                UrlReservations = new UrlReservations
                {
                    CreateAutomatically = true
                }
            };

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Running on {0}", url);
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }

            //using (var host = new NancyHost(config, uri))
            //{
            //    host.Start();

            //    Console.WriteLine("Your application is running on " + uri);
            //    Console.WriteLine("Press any [Enter] to close the host.");
            //    Console.ReadLine();
            //}
        }
    }
}
