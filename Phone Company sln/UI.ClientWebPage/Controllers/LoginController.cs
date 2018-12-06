using ClientBL.LoginService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UI.ClientWebPage.HardCodeds;
using UI.ClientWebPage.Models;

namespace UI.ClientWebPage.Controllers
{
    public class LoginController : ApiController
    {
        private readonly LoginService LOGIN_SERVICE;

        public LoginController()
        {
            LOGIN_SERVICE = new LoginService();
        }

        // POST api/login
        [HttpPost]
        [Route(nameof(ProjectFields.ROUTE_TO_LOGIN))]
        public bool Post([FromBody]LoginClient loginClient)
        {
            try
            {
                return LOGIN_SERVICE.Login(loginClient.Name, loginClient.ClientId);
            }
            catch (Exception ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }
}
