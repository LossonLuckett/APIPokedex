using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PokeLib 
{
    public static class ApiHelper
    {
        /// <summary>
        /// APIHelper class is meant to intialize out HttpClient type variable to store then pokemon base url and make sure our response comes back in JSON. 
        /// </summary>
        public static HttpClient ApiClient;
        public static void initClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
