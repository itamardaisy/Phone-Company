using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using UI.ClientWebPage.HardCodeds;

namespace UI.ClientWebPage.Helpers
{
    public static class UIHelper
    {
        public static HttpClient GetCurrentHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ProjectFields.BASE_ADDRESS);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ProjectFields.HEADER_TYPE));
            return httpClient;
        }
    }
}