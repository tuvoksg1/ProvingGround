using System;
using System.Threading.Tasks;
using Nancy;

namespace NancySelfHost.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Before += async (ctx, ct) =>
            {
                Console.WriteLine("Before Hook Delay");
                await Task.Delay(0);

                return null;
            };

            After += async (ctx, ct) =>
            {
                Console.WriteLine("After Hook Delay");
                await Task.Delay(0);
                Console.WriteLine("After Hook Complete");
            };

            Get["/", true] = async (parameters, token) =>
            {
                Console.WriteLine("Doing work");
                await Task.Delay(0);

                return Task.FromResult(View["index"]);
            };
        }
    }
}