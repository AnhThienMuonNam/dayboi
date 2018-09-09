using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayboi_Infrastructure.Repositories
{
    public interface IPaymentMethodRepository : IRepository<PaymentMethod>
    {
    }

    public class PaymentMethodRepository : RepositoryBase<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
