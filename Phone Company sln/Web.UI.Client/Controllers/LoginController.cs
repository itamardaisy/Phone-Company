using ClientBL.LoginService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.UI.Client.Models;

namespace Web.UI.Client.Controllers
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
        [Route("api/Login")]
        public bool Post([FromBody]LoginClient loginClient)
        {
            return LOGIN_SERVICE.Login(loginClient.Name, loginClient.ClientId);
        }
    }
}
