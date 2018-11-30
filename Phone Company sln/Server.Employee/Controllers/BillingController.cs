using System.Web.Http;

namespace Server.Employee.Controllers
{
    public class BillingController : ApiController
    {
        private const string Route = "api/Billing/";

        /// <summary>
        /// Calling The Create PDF Function from the API to the service
        /// </summary>
        [Route(Route + "CreatePDF")]
        [HttpGet]
        public string CreatePdf()
        {
            return "Hello World";
        }
    }
}