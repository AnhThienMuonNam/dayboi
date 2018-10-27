using Dayboi_Infrastructure.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Dayboi_Infrastructure
{
    public class DayboiDbContext : IdentityDbContext<ApplicationUser>
    {
        public DayboiDbContext() : base("DB_DayboiConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Category> Category { set; get; }

        public DbSet<Product> Product { set; get; }

        public DbSet<ApplicationGroup> ApplicationGroups { set; get; }
        public DbSet<ApplicationRole> ApplicationRoles { set; get; }
        public DbSet<ApplicationRoleGroup> ApplicationRoleGroups { set; get; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroups { set; get; }

        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<PaymentMethod> PaymentMethods { set; get; }
        public DbSet<OrderStatus> OrderStatuses { set; get; }
        public DbSet<Province> Provinces { set; get; }
        public DbSet<District> Districts { set; get; }
        public DbSet<Ward> Wards { set; get; }
        public DbSet<Blog> Blogs { set; get; }
        public DbSet<BlogTag> BlogTags { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<CourseTag> CourseTags { set; get; }
        public DbSet<Pool> Pools { set; get; }
        public DbSet<PoolTag> PoolTags { set; get; }
        public DbSet<PoolCategory> PoolCategories { set; get; }

        public static DayboiDbContext Create()
        {
            return new DayboiDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");
        }
    }
}