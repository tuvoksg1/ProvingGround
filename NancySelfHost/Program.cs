using System;
using Nancy.Hosting.Self;

namespace NancySelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri =
                new Uri("http://localhost:56000");

            var config = new HostConfiguration
            {
                UrlReservations = new UrlReservations
                {
                    CreateAutomatically = true
                }
            };

            using (var host = new NancyHost(config, uri))
            {
                host.Start();

                Console.WriteLine("Your application is running on " + uri);
                Console.WriteLine("Press any [Enter] to close the host.");
                Console.ReadLine();
            }
        }
    }
}
