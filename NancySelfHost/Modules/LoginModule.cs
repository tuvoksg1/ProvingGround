using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace NancySelfHost.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule()
        {
            Get["/core/custom/login", runAsync: true] = async (parameters, token) =>
            {
                Console.WriteLine("Doing work");
                await Task.Delay(0);

                return Task.FromResult(View["login"]);
            };

            Post["/core/custom/login", runAsync: true] = async (parameters, token) =>
            {
                Console.WriteLine("Doing work");
                await Task.Delay(0);

                return Task.FromResult(View["index"]);
            };
        }
    }
}
