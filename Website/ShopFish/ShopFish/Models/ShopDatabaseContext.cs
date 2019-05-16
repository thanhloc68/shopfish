using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace ShopFish.Models
{
    public class ShopDatabaseContext : DbContext
    {
        
        public ShopDatabaseContext() : base("name=ConnectDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopDatabaseContext, ShopFish.Migrations.Configuration>());
        }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Ordersdetails> Ordersdetails { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<TypeBlog> typeBlogs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<ShopFish.ViewModels.ResignViewModel> ResignViewModels { get; set; }

        public System.Data.Entity.DbSet<ShopFish.ViewModels.ContactViewModel> ContactViewModels { get; set; }

        public System.Data.Entity.DbSet<ShopFish.ViewModels.ChangePassword> ChangePasswords { get; set; }
   



    }
}
