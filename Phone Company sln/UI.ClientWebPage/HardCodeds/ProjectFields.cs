using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.ClientWebPage.HardCodeds
{
    public class ProjectFields
    {
        /*Home Controller*/
        internal static readonly string BASE_ADDRESS = "http://localhost:52036/";
        internal static readonly string ROUTE_TO_LOGIN = "api/Login";
        internal static readonly string ROUTE_TO_GetTotalMinuts = "api/GetTotalMinuts";
        internal static readonly string ROUTE_TO_GetTotalSMS = "api/GetTotalSMS";
        internal static readonly string ROUTE_TO_GetTotalMinutesTopNumber = "api/GetTotalMinutesTopNumber";
        internal static readonly string ROUTE_TO_GetTotalMinutesThreeTopNumber = "api/GetTotalMinutesThreeTopNumber";
        internal static readonly string ROUTE_TO_GetTotalMinutesFamily = "api/GetTotalMinutesFamily";
        internal static readonly string HEADER_TYPE = "application/json";
        internal static readonly string LOGIN_VIEW_NAME = "LoginView";
        internal static readonly string INDEX_VIEW_NAME = "index";
    }
}