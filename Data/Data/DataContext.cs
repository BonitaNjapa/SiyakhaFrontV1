using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.ShoppingCartM;

namespace Data
{
    public class DataContext : IdentityDbContext, IDbContext
    {
        public DataContext()
            : base("Conn")
        {

            Database.SetInitializer<DataContext>(new DbInitialize<DataContext>());
           // Database.SetInitializer<DataContext>(new CreateDatabaseIfNotExists<DataContext>());
           // Database.SetInitializer<DataContext>(new DropCreateDatabaseIfModelChanges<DataContext>());
           // Database.SetInitializer<DataContext>(new DropCreateDatabaseAlways<DataContext>());
        }

        #region Properties

        public DbSet<Item> Items { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> Cart_Items { get; set; }
        public DbSet<Cart> Carts { get; set; }
       // public DbSet<Customer> MealOrders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAddress> OrderAddresses { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderTracking> Order_Trackings { get; set; }

        public DbSet<Payment> Payments { get; set; }



        #endregion



        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");

            EntityTypeConfiguration<ApplicationUser> table =
                modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");

            table.Property((ApplicationUser u) => u.UserName).IsRequired();

            modelBuilder.Entity<ApplicationUser>().HasMany<IdentityUserRole>((ApplicationUser u) => u.Roles);
            modelBuilder.Entity<IdentityUserRole>().HasKey((IdentityUserRole r) =>
                new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("AspNetUserRoles");

            EntityTypeConfiguration<IdentityUserLogin> entityTypeConfiguration =
                modelBuilder.Entity<IdentityUserLogin>().HasKey((IdentityUserLogin l) =>
                    new
                    {
                        UserId = l.UserId,
                        LoginProvider = l.LoginProvider,
                        ProviderKey
                            = l.ProviderKey
                    }).ToTable("AspNetUserLogins");

            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");

            EntityTypeConfiguration<ApplicationRole> entityTypeConfiguration1 = modelBuilder.Entity<ApplicationRole>().ToTable("AspNetRoles");

            entityTypeConfiguration1.Property((ApplicationRole r) => r.Name).IsRequired();


        }
    }
}
