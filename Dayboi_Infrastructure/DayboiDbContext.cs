using Dayboi_Infrastructure.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayboi_Infrastructure
{
    public class DayboiDbContext: IdentityDbContext
    {
        public DayboiDbContext() : base("DB_DayboiConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<AspNetUser> AspNetUser { set; get; }
        public DbSet<Category> Category { set; get; }

        public DbSet<Product> Product { set; get; }

    }
}
