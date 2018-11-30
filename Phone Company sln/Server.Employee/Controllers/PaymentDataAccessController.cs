using System;
using System.Collections.Generic;
using System.Web.Http;
using BillingService.Services;
using Common.Models;

namespace Server.Employee.Controllers
{
    public class PaymentDataAccessController : ApiController
    {
        private const string Route = "api/PaymentDataAccess/";

        private readonly PaymentDataAccess paymentDataAccess = new PaymentDataAccess();

        [Route(Route + "GetClientMonthPayment")]
        [HttpGet]
        public ICollection<Payment> GetClientMonthPayment(int clientId, DateTime month)
        {
            return paymentDataAccess.GetClientMonthPayment(clientId, month);
        }

        [Route(Route + "GetPdfFileFromDataBaseAsByteArray")]
        [HttpGet]
        public byte[] GetPdfFileFromDataBaseAsByteArray()
        {
            return paymentDataAccess.GetPdfFileFromDataBaseAsByteArray();
        }

        [Route(Route + "SaveFileToDatabase")]
        [HttpPost]
        public void SaveFileToDatabase(string pdf)
        {
            throw new NotImplementedException();
        }
    }
}