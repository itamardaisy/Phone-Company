using BL.Services;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Employee.Controllers
{
    public class LoginController : ApiController
    {
        private LoginService loginService = new LoginService();
        private const string BASE_ADDRESS = "api/Login";

        [HttpPost]
        [Route(BASE_ADDRESS)]
        public User UserLogin([FromBody]User userLogin)
        {
            return loginService.Login(userLogin.Name, userLogin.Password);
        }
    }
}