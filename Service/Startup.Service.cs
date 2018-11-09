using Data;
using Domain;
using Microsoft.Owin;
using Owin;
using System;
using System.Web;
using Service.Identity;

namespace Service
{
    public static class Startup
    {

        

      
        //TODO Rename class 
        public static void OwinInit(IAppBuilder app)
        {

            app.CreatePerOwinContext(PiContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

        }

    }
}
