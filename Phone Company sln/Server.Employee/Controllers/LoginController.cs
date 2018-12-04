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

        [HttpPost]
        public User UserLogin()
        {
            return loginService.Login()
        }
    }
}