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
        private readonly DetailService DETAILS_SERVICE;

        public DetailsAPIController()
        {
            DETAILS_SERVICE = new DetailService();
        }

        [HttpPost]
        [Route("api/GetOptimalPackage")]
        public Package GetOptimalPackage([FromBody]DetailsModel detailsModel)
        {
            return DETAILS_SERVICE.GetOptimalPackages(detailsModel.CurrentClient, detailsModel.ChosenLine);
        }

        [HttpPost]
        [Route("api/GetTotalMinuts")]
        public double GetTotalMinuts([FromBody]DetailsModel detailsModel)
        {
            try
            {
                return DETAILS_SERVICE.GetTotalMinutes(detailsModel.CurrentClient, detailsModel.ChosenLine);
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
                return DETAILS_SERVICE.GetTotalSMS(detailsModel.CurrentClient, detailsModel.ChosenLine);
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
                return DETAILS_SERVICE.GetTotalMinutesTopNumber(detailsModel.CurrentClient, detailsModel.ChosenLine);
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
                return DETAILS_SERVICE.GetTotalMinutesThreeTopNumber(detailsModel.CurrentClient, detailsModel.ChosenLine);
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
                return DETAILS_SERVICE.GetTotalMinutesFamily(detailsModel.CurrentClient, detailsModel.ChosenLine);
            }
            catch (Exception ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }
}
