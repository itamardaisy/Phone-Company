using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UI.ClientWebPage.HardCodeds;
using UI.ClientWebPage.Models;

namespace UI.ClientWebPage.Controllers
{
    public class DetailsController : Controller
    {
        private HttpClient _client;

        public DetailsController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(ProjectFields.BASE_ADDRESS);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ProjectFields.HEADER_TYPE));
        }

        public ActionResult Index(DetailsModel detailsModel)
        {
            return View(ProjectFields.DETAILS_VIEW, detailsModel);
        }

        public ActionResult SetLine([FromBody]DetailsModel detailsModel)
        {
            string line = detailsModel.ChosenLine;
            detailsModel.TotalSMS = GetTotalSMS(detailsModel).Result;
            detailsModel.TotalMinuts = GetTotalMinuts(detailsModel).Result;
            detailsModel.TotalMinutesTopNumber = GetTotalMinutesTopNumber(detailsModel).Result;
            detailsModel.TotalMinutesThreeTopNumber = GetTotalMinutesThreeTopNumber(detailsModel).Result;
            detailsModel.TotalMinutesFamily = GetTotalMinutesFamily(detailsModel).Result;
            detailsModel.RecommendedPackages = GetOptimalPackage(detailsModel).Result;
            return View(ProjectFields.DETAILS_VIEW, detailsModel);
        }

        private async Task<List<Package>> GetOptimalPackage(DetailsModel detailsModel)
        {
            var response = _client.PostAsJsonAsync(ProjectFields.BASE_ADDRESS + ProjectFields.ROUTE_TO_GetOptimalPackage, detailsModel).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return await response.Content.ReadAsAsync<List<Package>>();
            else
                throw new Exception("Error");
        }

        private async Task<double> GetTotalMinuts(DetailsModel detailsModel)
        {
            var response = _client.PostAsJsonAsync(ProjectFields.BASE_ADDRESS + ProjectFields.ROUTE_TO_GetTotalMinuts, detailsModel).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return await response.Content.ReadAsAsync<double>();
            else
                throw new Exception("Error");
        }

        private async Task<int> GetTotalSMS(DetailsModel detailsModel)
        {
            var response = _client.PostAsJsonAsync(ProjectFields.BASE_ADDRESS + ProjectFields.ROUTE_TO_GetTotalSMS, detailsModel).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsAsync<int>();
            }
            else
                throw new Exception("Error");
        }

        private async Task<double> GetTotalMinutesTopNumber(DetailsModel detailsModel)
        {
            var response = _client.PostAsJsonAsync(ProjectFields.BASE_ADDRESS + ProjectFields.ROUTE_TO_GetTotalMinutesTopNumber, detailsModel).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsAsync<double>();
            }
            else
                throw new Exception("Error");
        }

        private async Task<double> GetTotalMinutesThreeTopNumber(DetailsModel detailsModel)
        {
            var response = _client.PostAsJsonAsync(ProjectFields.BASE_ADDRESS + ProjectFields.ROUTE_TO_GetTotalMinutesThreeTopNumber, detailsModel).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsAsync<double>();
            }
            else
                throw new Exception("Error");
        }

        private async Task<double> GetTotalMinutesFamily(DetailsModel detailsModel)
        {
            var response = _client.PostAsJsonAsync(ProjectFields.BASE_ADDRESS + ProjectFields.ROUTE_TO_GetTotalMinutesFamily, detailsModel).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsAsync<double>();
            }
            else
                throw new Exception("Error");
        }
    }
}