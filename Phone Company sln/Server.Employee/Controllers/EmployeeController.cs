using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Employee.Controllers
{
    public class EmployeeController : ApiController
    {
        private const string route = "api/employee/";

        [Route(route + "AddNewClient")]
        [HttpPost]
        public void AddNewClient(Client client)
        {
            throw new NotImplementedException();
        }

        [Route(route + "DeleteClient")]
        [HttpDelete]
        public bool DeleteClient(int id)
        {
            throw new NotImplementedException();
        }

        [Route(route + "FindOptimizePackage")]
        [HttpGet]
        public Package FindOptimizePackage(Client client)
        {
            throw new NotImplementedException();
        }

        [Route(route + "GetClient")]
        [HttpGet]
        public Client GetClient(string lineNumber, string clientName)
        {
            throw new NotImplementedException();
        }

        [Route(route + "GetClientTypes")]
        [HttpGet]
        public List<ClientType> GetClientTypes()
        {
            throw new NotImplementedException();
        }

        [Route(route + "GetReceiptByMonth")]
        [HttpGet]
        public Receipt GetReceiptByMonth(int clientId, DateTime month)
        {
            throw new NotImplementedException();
        }

        [Route(route + "UpdateClientDetails")]
        [HttpPut]
        public void UpdateClientDetails(Client client)
        {
            throw new NotImplementedException();
        }
    }
}