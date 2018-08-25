using Dayboi_Infrastructure.Infrastructures;
using Dayboi_Infrastructure.Models;
using Dayboi_Infrastructure.Repositories;
using Dayboi_Service.Account.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayboi_Service.Account
{
    public interface IAccountService
    {
        AspNetUser CreateUser(RegisterModel model);

    }
    public class AccountService : IAccountService
    {
        private IAspNetUsersRepository aspNetUsersRepository;
        private IUnitOfWork unitOfWork;
        public AccountService(IAspNetUsersRepository _aspNetUsersRepository, IUnitOfWork _unitOfWork)
        {
            aspNetUsersRepository = _aspNetUsersRepository;
            unitOfWork = _unitOfWork;
        }

        public AspNetUser CreateUser(RegisterModel model)
        {
            //do something
            


            //finally commit into database
            unitOfWork.Commit();
            throw new NotImplementedException();
        }


        
    }
}
