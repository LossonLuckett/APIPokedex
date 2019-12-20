using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokeLib
{

    /// <summary>
    /// PokeProcessor class is respondible for making the call to the PokeAPI https://pokeapi.co/
    /// The class contains an overloaded Task LoadPokeman  (One for strings and another for intergers) to allow the GUI users to seach by Pokemon name or Pokemon number
    /// The functions are async so that our GUI does not get locked while waiting for our JSON Request
    /// </summary>
    public class PokeProcessor  //Implements IPokeProcessor Interface
    {

        public StringBuilder url = new StringBuilder();
        public async Task<PokeModel> LoadPokemon(int PokeNumber)
        {
            //Since our ApiClient stores the base URL, 'https://pokeapi.co/api/v2/', for the API calls. All we need to do is concatinate for remainder of the API call in the correct format
            //Check for valid input, then format your Api call using StringBuilder url
            if (PokeNumber > 0)
            {
                url.Append( $"pokemon/" + PokeNumber.ToString());
            }
            else
            {
                url.Append($"pokemon/1");
            }

            //This opens and awaits a request from our ApiClient, the using brackets will close all ports and resources associated with response
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url.ToString().Trim()))
            {
                if(response.IsSuccessStatusCode)//If we get a response back, we will pass the data to our PokeModel
                {
                    PokeModel Pokemon = await response.Content.ReadAsAsync<PokeModel>();
                    url.Clear();
                    return Pokemon;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);//Throw us an error if we did not get any data returned
                    
                }
            }
        }


        public async Task<PokeModel> LoadPokemon(string PokeName)
        {            
            url.Append($"pokemon/" + PokeName);
            //This opens and awaits a request from our ApiClient, the using brackets will close all ports and resources associated with response
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url.ToString().Trim()))
            {
                if (response.IsSuccessStatusCode)//If we get a response back, we will look at the data.
                {
                    PokeModel Pokemon = await response.Content.ReadAsAsync<PokeModel>();
                    url.Clear();
                    return Pokemon;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);//Throw us an error if we did not get any data returned
                    
                }
            }
        }
    }
}
