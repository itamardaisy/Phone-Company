using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public ActionResult Login(LoginClient loginClient)
        {
            var response = client.PostAsJsonAsync(ProjectFields.BASE_ADDRESS + ProjectFields.ROUTE_TO_LOGIN, loginClient).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToActionPermanent(ProjectFields.INDEX_VIEW_NAME);
            }
            return View(ProjectFields.LOGIN_VIEW_NAME);
        }
    }
}
