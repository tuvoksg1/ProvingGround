using Nancy;
using Nancy.Owin;
using Owin;

namespace NancySelfHost
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

            option.PassThroughWhenStatusCodesAre(HttpStatusCode.ServiceUnavailable);
            app.UseNancy(option);
        }
    }
}
