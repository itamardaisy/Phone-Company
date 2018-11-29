using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Employee.Controllers
{
    public class BillingController : ApiController
    {
        private const string Route = "api/Billing/";

        [Route(Route + "CreatePDF")]
        [HttpGet]
        public string CreatePdf()
        {
            return "Hello World";
        }
    }
}