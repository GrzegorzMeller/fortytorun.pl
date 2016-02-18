using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FortyTorun.Models;
using System.Web.Security;

namespace FortyTorun.Controllers
{
    public class AccountController : Controller
    {

        // GET: Account
        public ViewResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            bool result = FormsAuthentication.Authenticate(model.UserName, model.Password);
            if(result)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                return Redirect(Url.Action("Index", "Admin"));
            }
            else
            {
                ModelState.AddModelError("", "Nieprawidłowa nazwa użykownika lub niepoprawne hasło");
                return View();
            }
        }
    }
}