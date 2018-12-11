using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UI.Employee.Helper
{
    internal static class HttpClientHelper
    {
        private const string BASE_ADDRESS = "http://localhost:50066/";
        private static HttpClient client;

        public static HttpClient CreateHttpClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(BASE_ADDRESS);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}