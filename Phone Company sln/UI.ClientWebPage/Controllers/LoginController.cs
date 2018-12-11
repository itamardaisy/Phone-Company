using ClientBL.DetailServices;
using ClientBL.LoginService;
using Common.Models;
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
        private readonly LoginService _loginService;
        private readonly DetailService _detailService;


        public LoginController()
        {
            _loginService = new LoginService();
            _detailService = new DetailService();
        }

        [HttpPost]
        [Route("api/Login")]
        public DetailsModel Login([FromBody]LoginClient loginClient)
        {
            try
            {
                if (_loginService.Login(loginClient.Name, loginClient.PhoneNumber) != null)
                {
                    Client client = _loginService.Login(loginClient.Name, loginClient.PhoneNumber);
                    DetailsModel detailsModel = new DetailsModel()
                    {
                        CurrentClient = client,
                        ClientLines = _detailService.GetClientLines(client.Id)
                    };
                    detailsModel.LineList(detailsModel.ClientLines);
                    return detailsModel;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }
}
