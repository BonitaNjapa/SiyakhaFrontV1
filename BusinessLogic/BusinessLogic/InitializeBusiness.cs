using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data;
using Microsoft.AspNet.Identity.EntityFramework;
namespace BusinessLogic
{
    public static class InitializeBusiness
    {
        public static void Initilize()
        {
            Database.SetInitializer<DataContext>(new DbInitialize<DataContext>());
            var ctx = new DataContext();
            ctx.Database.Initialize(true);
        }

    }
}
