using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI.ClientWebPage.HardCodeds;
using UI.ClientWebPage.Models;

namespace UI.ClientWebPage.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient client;

        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ProjectFields.BASE_ADDRESS);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ProjectFields.HEADER_TYPE));
        }

        public ActionResult Index()
        {
            return View(ProjectFields.LOGIN_VIEW_NAME);
        }

        public async Task<ActionResult> Login(LoginClient loginClient)
        {
            var response = client.PostAsJsonAsync(ProjectFields.ROUTE_TO_LOGIN, loginClient).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DetailsModel detailsModel = await response.Content.ReadAsAsync<DetailsModel>();
                return RedirectToActionPermanent(ProjectFields.DETAILS_VIEW, detailsModel);
            }
            return View(ProjectFields.LOGIN_VIEW_NAME);
        }
    }
}
