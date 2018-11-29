using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.Services;

namespace Server.Employee.Controllers
{
    public class EmployeeController : ApiController
    {
        private const string Route = "api/employee/";

        private readonly EmploeeService employeeService = new EmploeeService();

        [Route(Route + "AddNewClient")]
        [HttpPost]
        public void AddNewClient(Client client)
        {
            employeeService.AddNewClient(client);
        }

        [Route(Route + "DeleteClient")]
        [HttpDelete]
        public bool DeleteClient(int id)
        {
            return employeeService.DeleteClient(id);
        }

        [Route(Route + "FindOptimizePackage")]
        [HttpGet]
        public Package FindOptimizePackage(Client client)
        {
            return employeeService.FindOptimizePackage(client);
        }

        [Route(Route + "GetClient")]
        [HttpGet]
        public Client GetClient(string lineNumber, string clientName)
        {
            return employeeService.GetClient(lineNumber, clientName);
        }

        [Route(Route + "GetClientTypes")]
        [HttpGet]
        public List<ClientType> GetClientTypes()
        {
            return employeeService.GetClientTypes();
        }

        [Route(Route + "GetReceiptByMonth")]
        [HttpGet]
        public Receipt GetReceiptByMonth(int clientId, DateTime month)
        {
            return employeeService.GetReceiptByMonth(clientId, month);
        }

        [Route(Route + "UpdateClientDetails")]
        [HttpPut]
        public void UpdateClientDetails(Client client)
        {
            employeeService.UpdateClientDetails(client);
        }
    }
}