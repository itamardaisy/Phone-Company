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
        private const string route = "api/Billing/";

        [Route(route + "CreatePDF")]
        [HttpGet]
        public void CreatePDF()
        {
        }
    }
}