using Dayboi_Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayboi_Service
{
    public interface ITestService
    {
        void GetWinner();
     
    }
    public class TestService: ITestService
    {

       
        IAspNetUsersRepository aspNetUsersRepository;

        public TestService( IAspNetUsersRepository aspNetUsersRepository)
        {
            this.aspNetUsersRepository = aspNetUsersRepository;


        }



        public void GetWinner()
        {
           
        }
    }
}
