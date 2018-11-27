using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Employee.Controllers
{
    public class ManagerController : ApiController
    {
        private const string route = "api/manager/";

        [HttpPost]
        [Route(route + "AddNewPackage")]
        public void AddNewPackage(Package package)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route(route + "GetClientWhoMostLikelyToUnsign")]
        public List<Client> GetClientWhoMostLikelyToUnsign()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route(route + "GetMostAnoingClient")]
        public Client GetMostAnoingClient()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route(route + "GetMostConnectedClient")]
        public Client GetMostConnectedClient()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route(route + "GetMostProfitableClient")]
        public Client GetMostProfitableClient()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route(route + "GetMostValuentEmploee")]
        public User GetMostValuentEmploee()
        {
            throw new NotImplementedException();
        }
    }
}