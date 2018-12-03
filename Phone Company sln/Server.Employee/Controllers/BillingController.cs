using System.Web.Http;

namespace Server.Employee.Controllers
{
    public class BillingController : ApiController
    {
        private const string BASE_ROUTE = "api/Billing/";

        /// <summary>
        /// Calling The Create PDF Function from the API to the service
        /// </summary>
        [Route(BASE_ROUTE + "CreatePDF")]
        [HttpGet]
        public string CreatePdf()
        {
            return "Hello World";
        }
    }
}