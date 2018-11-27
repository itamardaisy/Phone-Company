using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class EmploeeService : IEmploeeService
    {
        public void AddNewClient(Client client)
        {
            throw new NotImplementedException();
        }

        public bool DeleteClient(int id)
        {
            throw new NotImplementedException();
        }

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