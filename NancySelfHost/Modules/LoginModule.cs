using System;
using System.Threading;
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
            Get["/core/custom/login/{id}", true] = LoginGet;

            Post["/core/custom/login/{test}", true] = LoginPost;
        }

        private async Task<dynamic> LoginGet(dynamic parameters, CancellationToken token)
        {
            await Task.Delay(0, token);
            var userId = ((DynamicDictionary)parameters)["id"].Value;
            return Negotiate
                .WithModel(new LoginModel { UserName = "Nancy", Password = "Reagan", SignInId = userId })
                .WithView("login");
        }

        private async Task<dynamic> LoginPost(dynamic parameters, CancellationToken token)
        {
            var model = this.Bind<LoginModel>();
            Console.WriteLine($"Logged in for {model.UserName}");
            await Task.Delay(0, token);

            return Response.AsRedirect("~/?status=test");
        }
    }
}
