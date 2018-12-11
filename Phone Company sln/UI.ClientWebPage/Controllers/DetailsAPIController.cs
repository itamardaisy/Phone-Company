using ClientBL.DetailServices;
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
    public class DetailsAPIController : ApiController
    {
        private readonly DetailService _detailService;

        public DetailsAPIController()
        {
            _detailService = new DetailService();
        }

        [HttpPost]
        [Route("api/GetOptimalPackage")]
        public List<Package> GetOptimalPackage([FromBody]DetailsModel detailsModel)
        {
            return _detailService.GetOptimalPackages(detailsModel.CurrentClient, detailsModel.ChosenLine);
        }

        [HttpPost]
        [Route("api/GetTotalMinuts")]
        public double GetTotalMinuts([FromBody]DetailsModel detailsModel)
        {
            try
            {
                return _detailService.GetTotalMinutes(detailsModel.CurrentClient, detailsModel.ChosenLine);
            }
            catch (Exception ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route("api/GetTotalSMS")]
        public int GetTotalSMS([FromBody]DetailsModel detailsModel)
        {
            try
            {
                return _detailService.GetTotalSMS(detailsModel.CurrentClient, detailsModel.ChosenLine);
            }
            catch (Exception ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route("api/GetTotalMinutesTopNumber")]
        public double GetTotalMinutesTopNumber([FromBody]DetailsModel detailsModel)
        {
            try
            {
                return _detailService.GetTotalMinutesTopNumber(detailsModel.CurrentClient, detailsModel.ChosenLine);
            }
            catch (Exception ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route("api/GetTotalMinutesThreeTopNumber")]
        public double GetTotalMinutesThreeTopNumber([FromBody]DetailsModel detailsModel)
        {
            try
            {
                return _detailService.GetTotalMinutesThreeTopNumber(detailsModel.CurrentClient, detailsModel.ChosenLine);
            }
            catch (Exception ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route("api/GetTotalMinutesFamily")]
        public double GetTotalMinutesFamily([FromBody]DetailsModel detailsModel)
        {
            try
            {
                return _detailService.GetTotalMinutesFamily(detailsModel.CurrentClient, detailsModel.ChosenLine);
            }
            catch (Exception ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }
}
