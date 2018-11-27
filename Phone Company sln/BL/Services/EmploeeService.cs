using Common.Interfaces;
using Common.Models;
using Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    class EmploeeService : IEmploeeService
    {
        private readonly ClientRepository CR;

        public EmploeeService()
        {
            CR = new ClientRepository();
        }

        public void AddNewClient(Client client)
        {
            try
            {
                CR.AddNewClient(client);
            }
            catch(InvalidOperationException ex) 
            {

            }
            catch ()
            {

            }
        }

        public bool DeleteClient(int id) => CR.DeleteClient(id);

        public Package FindOptimizePackage(Client client)
        {
            throw new NotImplementedException();
        }

        public Client GetClient(string lineNumber, string clientName)
        {
            throw new NotImplementedException();
        }

        public List<ClientType> GetClientTypes()
        {
            throw new NotImplementedException();
        }

        public Receipt GetReceiptByMonth(int clientId, DateTime month)
        {
            throw new NotImplementedException();
        }

        public void UpdateClientDetails(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
