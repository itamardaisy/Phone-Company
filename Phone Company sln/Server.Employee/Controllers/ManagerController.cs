using Common.Models;
using System.Collections.Generic;
using System.Web.Http;
using BL.Services;

namespace Server.Employee.Controllers
{
    public class ManagerController : ApiController
    {
        private const string Route = "api/manager/";
        private readonly ManagerService managerService = new ManagerService();

        [HttpPost]
        [Route(Route + "AddNewPackage")]
        public void AddNewPackage(Package package)
        {
            managerService.AddNewPackage(package);
        }

        [HttpGet]
        [Route(Route + "GetClientWhoMostLikelyToUnsigned")]
        public List<Client> GetClientWhoMostLikelyToUnsigned()
        {
            return managerService.GetClientWhoMostLikelyToUnsign();
        }

        [HttpGet]
        [Route(Route + "GetMostAnnoyingClient")]
        public Client GetMostAnnoyingClient()
        {
            return managerService.GetMostAnoingClient();
        }

        [HttpGet]
        [Route(Route + "GetMostConnectedClient")]
        public List<Client> GetMostConnectedClient()
        {
            return managerService.GetMostConnectedClients();
        }

        [HttpGet]
        [Route(Route + "GetMostProfitableClient")]
        public Client GetMostProfitableClient()
        {
            return managerService.GetMostProfitableClient();
        }

        [HttpGet]
        [Route(Route + "GetMostValuentEmployee")]
        public User GetMostValuentEmployee()
        {
            return managerService.GetMostValuentEmploee();
        }
    }
}