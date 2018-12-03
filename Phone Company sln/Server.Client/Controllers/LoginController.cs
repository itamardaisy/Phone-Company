using ClientBL.LoginService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Client.Controllers
{
    public class LoginController : Controller
    {
        private const string BASE_ROUTE = "api/Logi/";
        private readonly LoginService LOGIN_SERVICE;

        public LoginController()
        {
            LOGIN_SERVICE = new LoginService();
        }

        [HttpPost]
        [Route(BASE_ROUTE + "Login")]
        public bool Login(string name, int clientId)
        {
            return LOGIN_SERVICE.Login(name, clientId);
        }
    }
}