using Common.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using BL.Services;

namespace Server.Employee.Controllers
{
    public class EmployeeController : ApiController
    {
        private const string Route = "api/employee/";

        private readonly EmploeeService employeeService = new EmploeeService();

        /// <summary>
        /// Calling the addNewClient function from the API to the service
        /// </summary>
        /// <param name="client"></param>
        [Route(Route + "AddNewClient")]
        [HttpPost]
        public void AddNewClient(Client client)
        {
            employeeService.AddNewClient(client);
        }

        /// <summary>
        /// Calling the deleteClient function from the API to the service
        /// </summary>
        /// <param name="id"> Get the Id of the client from some UI </param>
        /// <returns> true if the user was deleted, false if he didn't </returns>
        [Route(Route + "DeleteClient")]
        [HttpDelete]
        public bool DeleteClient(int id)
        {
            return employeeService.DeleteClient(id);
        }

        /// <summary>
        /// Calling the findOptimizePackage from the API to the service
        /// that calculate the best package for the user
        /// </summary>
        /// <param name="client"> Gets the client that want more optimal package </param>
        /// <returns> The optimal package </returns>
        [Route(Route + "FindOptimizePackage")]
        [HttpGet]
        public Package FindOptimizePackage(Client client)
        {
            return employeeService.FindOptimizePackage(client);
        }

        /// <summary>
        /// Calling the GetClient function from the API to the service
        /// </summary>
        /// <param name="lineNumber"> The line number of the client </param>
        /// <param name="clientName"> The name of the client </param>
        /// <returns> The client that we asked for </returns>
        [Route(Route + "GetClient")]
        [HttpGet]
        public Client GetClient(string lineNumber, string clientName)
        {
            return employeeService.GetClient(lineNumber, clientName);
        }

        /// <summary>
        /// Calling the GetClientTypes from the API to the service
        /// </summary>
        /// <returns> All ClientTypes that in the DB </returns>
        [Route(Route + "GetClientTypes")]
        [HttpGet]
        public List<ClientType> GetClientTypes()
        {
            return employeeService.GetClientTypes();
        }

        /// <summary>
        /// Calling the GetReceiptByMonth from the API to the server
        /// </summary>
        /// <param name="clientId"> Getting the clientId to find the receipt for him </param>
        /// <param name="month"> Getting the month the receipt the client wants to get </param>
        /// <returns> Returns the receipt for the client </returns>
        [Route(Route + "GetReceiptByMonth")]
        [HttpGet]
        public Receipt GetReceiptByMonth(int clientId, DateTime month)
        {
            return employeeService.GetReceiptByMonth(clientId, month);
        }

        /// <summary>
        /// Calling the UpdateClientDetails function from the API to the service
        /// </summary>
        /// <param name="client"></param>
        [Route(Route + "UpdateClientDetails")]
        [HttpPut]
        public void UpdateClientDetails(Client client)
        {
            employeeService.UpdateClientDetails(client);
        }
    }
}