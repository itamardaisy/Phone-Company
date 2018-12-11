using Common.Interfaces;
using Common.Interfaces.ClientBL_Interfaces;
using Common.Interfaces.UI.Client_Interfaces;
using Common.Models;
using Dal.DataInitializer;
using Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientBL.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly IClientRepository _clientRepository;

        public LoginService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        
        /// <summary>
        /// Checks the client with the database
        /// </summary>
        /// <param name="name"> The name of the client </param>
        /// <param name="clientId"> The id of the client </param>
        /// <returns> Return true if the client exist, otherwise false. </returns>
        public Client Login(string name, string phoneNumber)
        {
            if (_clientRepository.LoginClient(name, phoneNumber) != null)  
                return _clientRepository.LoginClient(name, phoneNumber);
            return null;
        }
    }
}
