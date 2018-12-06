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
    public class DetailsController : Controller
    {
        private HttpClient client;

        public DetailsController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ProjectFields.BASE_ADDRESS);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ProjectFields.HEADER_TYPE));
        }

        public ActionResult Index()
        {
            return View(ProjectFields.INDEX_VIEW_NAME);
        }

        public async double GetTotalMinuts(DetailsModel detailsModel)
        {
            var response = client.PostAsJsonAsync(ProjectFields.BASE_ADDRESS + ProjectFields.ROUTE_TO_GetTotalMinuts, detailsModel).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return await response.Content.ReadAsAsync<double>();
            else
                return -1;
        }

        public ActionResult GetTotalSMS(DetailsModel detailsModel)
        {
            var response = client.PostAsJsonAsync(ProjectFields.BASE_ADDRESS + ProjectFields.ROUTE_TO_GetTotalSMS, detailsModel).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToActionPermanent(ProjectFields.INDEX_VIEW_NAME);
            }
            return View(ProjectFields.LOGIN_VIEW_NAME);
        }
    }
}