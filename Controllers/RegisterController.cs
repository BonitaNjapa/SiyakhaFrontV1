using BusinessLogic;
using Microsoft.Owin.Security;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SiyakhaFrontV1.Controllers
{
    public class RegisterController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        // GET: Register
        [Route("/Register")]
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Index(RegisterModel objRegisterModel)
        {
            if (ModelState.IsValid)
            {
                var registerbusiness = new RegisterBusiness();

                if (registerbusiness.FindUser(objRegisterModel.Email, AuthenticationManager))
                {
                    ModelState.AddModelError("", "User already exists");
                    return View(objRegisterModel);
                }
                var result = await registerbusiness.RegisterUser(objRegisterModel, AuthenticationManager);
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", result.ToString());
                }
            }

            return View(objRegisterModel);
        }
    }
}