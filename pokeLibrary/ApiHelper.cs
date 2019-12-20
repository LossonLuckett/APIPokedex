using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace pokeLibrary
{
    public static class ApiHelper
    {
        //An API call, add webclient.api by right clicking pokeLibrary.references manage NuGet packages and Browser for webclient.api, install. Then check for updates in the update tab

        public static HttpClient ApiClient { get; set; } //This is connecting our program to the web, instantiating a web browser.

        public static void InitializeClient()
        {
         
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new  MediaTypeWithQualityHeaderValue("application/json")); //Says return my information in JSON, so that it can be easily parsed into models.
        }

    }
}
