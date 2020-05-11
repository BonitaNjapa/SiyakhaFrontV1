using Data.ShoppingCartM;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DbInitialize<T> : DropCreateDatabaseIfModelChanges<IdentityDbContext>
    {
        protected override void Seed(IdentityDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new
                                            UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<ApplicationRole>(new
                                      RoleStore<ApplicationRole>(context));
            const string name = "Admin";
            const string password = "Password01";
            #region addAllRoles
            //if (!roleManager.RoleExists(name))
            //{
            //    var roleresult = roleManager.Create(new ApplicationRole(name));
            //}
            //if (!roleManager.RoleExists("Clerk"))
            //{
            //    roleManager.Create(new ApplicationRole("Clerk"));
            //}

            //if (!roleManager.RoleExists("Customer"))
            //{
            //    roleManager.Create(new ApplicationRole("Customer"));
            //}
            //if (!roleManager.RoleExists("Merchandise"))
            //{
            //     roleManager.Create(new ApplicationRole("Merchandise"));
            //}
            //if (!roleManager.RoleExists("Manager"))
            //{
            //    roleManager.Create(new ApplicationRole("Manager"));
            //}
            #endregion
            var user = new ApplicationUser();
            user.UserName = name;
            var adminresult = userManager.Create(user, password);

            if (adminresult.Succeeded)
            {
                var result = userManager.AddToRole(user.Id, name);
            }
            context.Set<Category>().Add(new Category()
            {
                Category_ID = 1,
                Name = "Food & Drink",
            });
            base.Seed(context);

        }
    }
}

