using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IEmploeeService
    {
        void AddNewClient(Client client);

        void UpdateClientDetails(Client client);

        Client GetClient(int clientID);

        bool DeleteClient(int id);

        Package FindOptimizePackage(Client client);

        List<ClientType> GetClientTypes();

        Receipt GetReceiptByMonth(int clientId, DateTime month);
    }
}