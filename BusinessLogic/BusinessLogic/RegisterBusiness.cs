using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Model;

namespace BusinessLogic
{
    public class RegisterBusiness
    {
        public UserManager<ApplicationUser> UserManager { get; set; }

        public RegisterBusiness()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DataContext()));
        }

        public bool FindUser(string userName, IAuthenticationManager authenticationManager)
        {
            var user = UserManager.FindByName(userName);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RegisterUser(RegisterModel objRegisterModel, IAuthenticationManager authenticationManager)
        {
            var newuser = new ApplicationUser { 
                UserName = objRegisterModel.Email,
                Email = objRegisterModel.Email,
                FirstName = objRegisterModel.FirstName, 
                LastName = objRegisterModel.LastName
            };


            var result = await UserManager.CreateAsync(
               newuser, objRegisterModel.Password);

            if (result.Succeeded)
            {
                DataContext dataContext = new DataContext(); dataContext.Customers.Add(new Customer
                {
                    UserName = objRegisterModel.Email,
                    Email = objRegisterModel.Email,
                    FirstName = objRegisterModel.FirstName,
                    LastName = objRegisterModel.LastName
                });

                await SignInAsync(newuser, false, authenticationManager);
                return true;
            }
            return false;
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent, IAuthenticationManager authenticationManager)
        {
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public bool AddUserToRole(string user, string role)
        {
            var result = UserManager.AddToRole(user, role);

            return result.Succeeded;
        }
    }
}
