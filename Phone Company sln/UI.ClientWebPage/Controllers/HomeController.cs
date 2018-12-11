﻿using System;
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
        private HttpClient _client;

        public HomeController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(ProjectFields.BASE_ADDRESS);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ProjectFields.HEADER_TYPE));
        }

        public ActionResult Index()
        {
            return View(ProjectFields.LOGIN_VIEW_NAME);
        }

        public async Task<ActionResult> Login(LoginClient loginClient)
        {
            var response = _client.PostAsJsonAsync(ProjectFields.ROUTE_TO_LOGIN, loginClient).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DetailsModel detailsModel = await response.Content.ReadAsAsync<DetailsModel>();
                return RedirectToAction("Index", "Details", detailsModel);
            }
            return View(ProjectFields.LOGIN_VIEW_NAME);
        }
    }
}
