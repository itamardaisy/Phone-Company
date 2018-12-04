using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using UI.Client.Models;

namespace UI.Client.Controllers
{
    public class HomeController : Controller
    {
        private const string BASE_ADDRESS = "http://localhost:51418/";
        private HttpClient client;

        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(BASE_ADDRESS);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ActionResult Index()
        {
            return View("LoginView");
        }

        public ActionResult Login(Models.Client clientModel)
        {
            var response = client.PostAsJsonAsync(BASE_ADDRESS+"api/Login/Login", clientModel).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToActionPermanent("Index");
            }
            return View("LoginView");
        }
    }
}