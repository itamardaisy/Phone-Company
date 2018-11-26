using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IManagerService
    {
        void AddNewPackage(Package package);

        User GetMostValuentEmploee();

        Client GetMostProfitableClient();

        Client GetMostAnoingClient();

        Client GetMostConnectedClient();

        List<Client> GetClientWhoMostLikelyToUnsign();
    }
}
