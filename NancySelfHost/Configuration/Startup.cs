using IdentityServer3.Core.Configuration;
using Nancy;
using Nancy.Owin;
using NancySelfHost.Entities;
using Owin;

namespace NancySelfHost.Configuration
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var option = new NancyOptions
            {
                Bootstrapper = new Bootstrapper(),
                PerformPassThrough = context =>
                  context.Response.StatusCode == HttpStatusCode.NotFound
            };

            //option.PassThroughWhenStatusCodesAre(HttpStatusCode.ServiceUnavailable);
            app.UseNancy(option);
            //app.UseNancy();

            app.Map("/core",
            coreApp =>
            {
                coreApp.UseIdentityServer(new IdentityServerOptions
                {
                    SiteName = "Standalone Identity Server",
                    SigningCertificate = Certificate.Get(),
                    Factory = new IdentityServerServiceFactory()
                            .UseInMemoryClients(Clients.Get())
                            .UseInMemoryScopes(Scopes.Get())
                            .UseInMemoryUsers(Users.Get())
                });
            });
        }
    }
}
