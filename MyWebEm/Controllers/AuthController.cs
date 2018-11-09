using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebEm.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
          [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View();
        }
    }
}