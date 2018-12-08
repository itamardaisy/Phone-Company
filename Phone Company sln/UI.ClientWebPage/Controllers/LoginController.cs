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
        private readonly LoginService LOGIN_SERVICE;
        private readonly DetailService DETAIL_SERVICE;

        public LoginController()
        {
            LOGIN_SERVICE = new LoginService();
            DETAIL_SERVICE = new DetailService();
        }

        [HttpPost]
        [Route(nameof(ProjectFields.ROUTE_TO_LOGIN))]
        public DetailsModel Post([FromBody]LoginClient loginClient)
        {
            try
            {
                if (LOGIN_SERVICE.Login(loginClient.Name, loginClient.ClientId) != null)
                {
                    Client client = LOGIN_SERVICE.Login(loginClient.Name, loginClient.ClientId);
                    DetailsModel detailsModel = new DetailsModel()
                    {
                        CurrentClient = client,
                        ClientLines = DETAIL_SERVICE.GetClientLines(client.Id)
                    };
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
