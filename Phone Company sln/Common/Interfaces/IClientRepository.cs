using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IClientRepository
    {
        Client AddNewClient(Client client);

        Client UpdateClient(Client client);

        Client GetClientById(int id);
    }
}
