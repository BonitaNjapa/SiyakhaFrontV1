using Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiyakhaFrontV1.Controllers
{
    public class UserManangerController : Controller
    {
        Data.DataContext context = new DataContext();
        // GET: UserMananger
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string UserName = form["txtEmail"];
            string email = form["txtEmail"];
            string pwd = form["txtPassword"];

            var user = new ApplicationUser();
            user.UserName = UserName;
            user.Email = email;
            
            var newuser = userManager.Create(user, pwd);

            return View();
        }
        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewRole(FormCollection form)
        {

            string rolename = form["RoleName"];
            var roleMananger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleMananger.RoleExists(rolename))
            {
                var role = new IdentityRole(rolename);
                roleMananger.Create(role);
            }

            return View("Index");

        }
        public ActionResult AssignRole()
        {
            ViewBag.Roles = context.Roles.Select(c => new SelectListItem { Value = c.Name, Text = c.Name }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AssignRole(FormCollection form)
        {
            string username = form["txtUserName"];
            string rolename = form["RoleName"];
            ApplicationUser user = (ApplicationUser)context.Users.Where(w => w.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.AddToRole(user.Id, rolename);

            return View("Index");

        }
    }
}