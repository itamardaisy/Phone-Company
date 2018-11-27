using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Employee.Controllers
{
    public class PaymentDataAccessController : ApiController
    {
        private const string route = "api/PaymentDataAccess/";

        [Route(route + "GetClientMonthPayment")]
        [HttpGet]
        public void GetClientMonthPayment()
        {
        }

        [Route(route + "GetPdfFileFromDataBaseAsByteArray")]
        [HttpGet]
        public void GetPdfFileFromDataBaseAsByteArray()
        {
        }

        [Route(route + "SaveFileToDatabase")]
        [HttpPost]
        public void SaveFileToDatabase()
        {
        }
    }
}