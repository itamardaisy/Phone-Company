using Common.Interfaces;
using Common.Interfaces.ClientBL_Interfaces;
using Dal.DataInitializer;
using Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientBL.LoginService
{
    public class LoginService : IClientLoginService
    {
        private readonly ClientRepository CLIENT_REPOSITORY;

        public LoginService()
        {
            PhoneCompanyContext context = new PhoneCompanyContext();
            CLIENT_REPOSITORY = new ClientRepository(context);
        }

        public bool Login(string name, int clientId)
        {
            if (CLIENT_REPOSITORY.LoginClient(name, clientId))
                return true;
            return false;
        }
    }
}
