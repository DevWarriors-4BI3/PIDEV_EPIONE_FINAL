using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {

        public async System.Threading.Tasks.Task<string> AddUser()
        {
            //  AppService s = new AppService();
          //  s.TestContext();


            ServiceUser us = new ServiceUser();
            var user = new User
            {
                UserName = "TestUser",
                Email = "TestUser@test.com"
            };


            var result = await us.UserManager.CreateAsync(user);
            if (!result.Succeeded)
            {
              return result.Errors.First();
           }
            return "User Added";
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}