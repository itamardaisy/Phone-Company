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
    public class ManagerService : IManagerService
    {
        private readonly ManagerRepository MR;

        public ManagerService()
        {
            MR = new ManagerRepository();
        }

        public void AddNewPackage(Package package)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetClientWhoMostLikelyToUnsign()
        {
            throw new NotImplementedException();
        }

        public Client GetMostAnoingClient()
        {
            throw new NotImplementedException();
        }

        public Client GetMostConnectedClient()
        {
            throw new NotImplementedException();
        }

        public Client GetMostProfitableClient()
        {
            throw new NotImplementedException();
        }

        public User GetMostValuentEmploee()
        {
            throw new NotImplementedException();
        }
    }
}
