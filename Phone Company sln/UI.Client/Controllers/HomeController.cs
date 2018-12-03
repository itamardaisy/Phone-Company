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

        public ActionResult Login(Models.Client clientModel)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:63465/");

            HttpResponseMessage response = client.PostAsync("api/Login/Login").Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToActionPermanent("Index", "Project");
            }
            return View(clientModel);
        }
    }
}