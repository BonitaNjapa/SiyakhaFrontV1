using Microsoft.Owin.Security;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using BusinessLogic;

namespace SiyakhaFrontV1.Controllers
{
   // [Authorize]
    public class LoginController : Controller
    {

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: Login
        //[Route("/Login")]

        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Index(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var loginbusiness = new LoginBusiness();
                var result = await loginbusiness.LogUserIn(model, AuthenticationManager);
                if (result)
                    return RedirectToLocal(returnUrl);
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

       

    }
}