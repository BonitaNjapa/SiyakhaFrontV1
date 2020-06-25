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
        }

        #region Properties

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CartItem> Cart_Items { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        // public  virtualDbSet<Customer> MealOrders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderAddress> OrderAddresses { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<OrderTracking> Order_Trackings { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<CompSuppManager.Supplier> Suppliers { get; set; }

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

        public System.Data.Entity.DbSet<Data.CompSuppManager.Branch> Branches { get; set; }

        public System.Data.Entity.DbSet<Data.CompSuppManager.BranchAddress> BranchAddresses { get; set; }
    }
}
