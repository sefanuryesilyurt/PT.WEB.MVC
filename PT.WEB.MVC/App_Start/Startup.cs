using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(PT.WEB.MVC.App_Start.Startup))]

namespace PT.WEB.MVC.App_Start
{
    //Uygulama çalışmadan önce çalışır.. app adında ınterface geliyo.
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication (new CookieAuthenticationOptions
                {

                AuthenticationType="ApplicationCookie",
                LoginPath=new PathString("/Account/Login")

            });


            // Uygulamanızı nasıl  yapılandıracağınız hakkında daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=316888 adresini ziyaret edin
        }
    }
}
