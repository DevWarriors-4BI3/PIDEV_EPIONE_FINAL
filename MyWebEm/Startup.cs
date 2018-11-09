using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartupAttribute(typeof(MyWebEm.Startup))]
namespace MyWebEm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            //OwinInit(app);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            //ConfigureAuth(app);
        }
    }
}
