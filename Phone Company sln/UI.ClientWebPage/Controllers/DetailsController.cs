using Common.Models;
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

        public ActionResult SetLine(string chosenLine)
        {
            DetailsModel detailModel = new DetailsModel()
            {
                ChosenLine = chosenLine,
            };
            return View("Details", detailModel);
        }

        private async Task<Package> GetOptimalPackage(DetailsModel detailsModel)
        {
            var response = client.PostAsJsonAsync(ProjectFields.BASE_ADDRESS + ProjectFields.ROUTE_TO_GetOptimalPackage, detailsModel).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return await response.Content.ReadAsAsync<Package>();
            else
                throw new Exception("Error");
        }

        public async Task<double> GetTotalMinuts(DetailsModel detailsModel)
        {
            var response = client.PostAsJsonAsync(ProjectFields.BASE_ADDRESS + ProjectFields.ROUTE_TO_GetTotalMinuts, detailsModel).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return await response.Content.ReadAsAsync<double>();
            else
                throw new Exception("Error");
        }

        public async Task<int> GetTotalSMS(DetailsModel detailsModel)
        {
            var response = client.PostAsJsonAsync(ProjectFields.BASE_ADDRESS + ProjectFields.ROUTE_TO_GetTotalSMS, detailsModel).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsAsync<int>();
            }
            else
                throw new Exception("Error");
        }

        public async Task<double> GetTotalMinutesTopNumber(DetailsModel detailsModel)
        {
            var response = client.PostAsJsonAsync(ProjectFields.BASE_ADDRESS + ProjectFields.ROUTE_TO_GetTotalMinutesTopNumber, detailsModel).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsAsync<double>();
            }
            else
                throw new Exception("Error");
        }

        public async Task<double> GetTotalMinutesThreeTopNumber(DetailsModel detailsModel)
        {
            var response = client.PostAsJsonAsync(ProjectFields.BASE_ADDRESS + ProjectFields.ROUTE_TO_GetTotalMinutesThreeTopNumber, detailsModel).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsAsync<double>();
            }
            else
                throw new Exception("Error");
        }

        public async Task<double> GetTotalMinutesFamily(DetailsModel detailsModel)
        {
            var response = client.PostAsJsonAsync(ProjectFields.BASE_ADDRESS + ProjectFields.ROUTE_TO_GetTotalMinutesFamily, detailsModel).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsAsync<double>();
            }
            else
                throw new Exception("Error");
        }
    }
}