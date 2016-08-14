using Nancy.Owin;
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
            };

            //app.UseNancy(option);
            app.UseNancy();
        }
    }
}
