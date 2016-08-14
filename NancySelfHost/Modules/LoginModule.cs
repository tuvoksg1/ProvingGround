using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.ModelBinding;
using NancySelfHost.Models;

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

                //return Task.FromResult(View["login"]);

                return View["login"];
                //return Negotiate
                //    .WithModel(new LoginModel {UserName = "Nancy", Password = "Reagan"})
                //    .WithView("login");
            };

            Post["/core/custom/login", runAsync: true] = async (parameters, token) =>
            {
                var model = this.Bind<LoginModel>();
                Console.WriteLine($"Logged in for {model.UserName}");
                await Task.Delay(0);

                return Response.AsRedirect("~/");
                //return Task.FromResult(View["index"]);
            };
        }
    }
}
