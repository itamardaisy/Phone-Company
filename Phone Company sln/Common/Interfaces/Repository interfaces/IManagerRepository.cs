using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IManagerRepository
    {
        List<Payment> GetClientReport(int clientId);

        User GetMostvalentEmployee();

        Client GetMostProftableClient();

        Client GetMostAnoyingClient();

        List<Client> GetMostConectedClients();

        List<Client> GetClientWhoMostLikleyToUnsign();
    }
}
