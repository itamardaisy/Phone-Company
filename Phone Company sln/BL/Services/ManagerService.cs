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
        private readonly PackageRepository PR;

        public ManagerService()
        {
            MR = new ManagerRepository();
            PR = new PackageRepository();
        }

        public void AddNewPackage(Package package)
        {
            PR.AddNewPackage(package);
        }

        public List<Client> GetClientWhoMostLikelyToUnsign()
        {
            return MR.GetClientWhoMostLikelyToUnsign();
        }

        public Client GetMostAnoingClient()
        {
            return MR.GetMostAnoyingClient();
        }

        public List<Client> GetMostConnectedClients()
        {
            return MR.GetMostConectedClients();
        }

        public Client GetMostProfitableClient()
        {
            return MR.GetMostProftableClient();
        }

        public User GetMostValuentEmploee()
        {
            return MR.GetMostvalentEmployee();
        }
    }
}