using ClientBL.DetailServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.UI.Client.HardCodeds;
using Web.UI.Client.Models;

namespace Web.UI.Client.Controllers
{
    public class DetailsAPIController : ApiController
    {
        private readonly DetailService DETAILS_SERVICE;

        public DetailsAPIController()
        {
            DETAILS_SERVICE = new DetailService();
        }

        [HttpPost]
        [Route(nameof(ProjectFields.ROUTE_TO_GetTotalMinuts))]
        public double GetTotalMinuts([FromBody]DetailsModel detailsModel)
        {
            try
            {
                return DETAILS_SERVICE.GetTotalMinutes(detailsModel.CurrentClient, detailsModel.LineNumber);
            }
            catch (Exception ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route(nameof(ProjectFields.ROUTE_TO_GetTotalSMS))]
        public int GetTotalSMS([FromBody]DetailsModel detailsModel)
        {
            try
            {
                return DETAILS_SERVICE.GetTotalSMS(detailsModel.CurrentClient, detailsModel.LineNumber);
            }
            catch(Exception ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route(nameof(ProjectFields.ROUTE_TO_GetTotalMinutesTopNumber))]
        public double GetTotalMinutesTopNumber([FromBody]DetailsModel detailsModel)
        {
            try
            {
                return DETAILS_SERVICE.GetTotalMinutesTopNumber(detailsModel.CurrentClient, detailsModel.LineNumber);
            }
            catch(Exception ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route(nameof(ProjectFields.ROUTE_TO_GetTotalMinutesThreeTopNumber))]
        public double GetTotalMinutesThreeTopNumber([FromBody]DetailsModel detailsModel)
        {
            try
            {
                return DETAILS_SERVICE.GetTotalMinutesThreeTopNumber(detailsModel.CurrentClient, detailsModel.LineNumber);
            }
            catch(Exception ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route(nameof(ProjectFields.ROUTE_TO_GetTotalMinutesFamily))]
        public double GetTotalMinutesFamily([FromBody]DetailsModel detailsModel)
        {
            try
            {
                return DETAILS_SERVICE.GetTotalMinutesFamily(detailsModel.CurrentClient, detailsModel.LineNumber);
            }
            catch(Exception ex)
            {
                Common.EnvironmentService.Services.WriteExceptionsToLogger(ex);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }
}
