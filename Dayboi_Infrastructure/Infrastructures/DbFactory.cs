using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayboi_Infrastructure.Infrastructures
{
    public class DbFactory : Disposable, IDbFactory
    {
        private DayboiDbContext dbContext;

        public DayboiDbContext Init()
        {
            return dbContext ?? (dbContext = new DayboiDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
