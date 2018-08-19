using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayboi_Infrastructure.Infrastructures
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
