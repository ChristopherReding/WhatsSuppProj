using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using unirest_net.http;
using WhatsSupp.Contracts;

namespace WhatsSupp.Services
{
    public class RapidAPI : IRapidAPIRepository
    {
        public RapidAPI()
        {
        }

        public async Task<NearbyRestaurants> GetNearbyRestaurants(Geolocation coordinates, double searchRadius, string preferences)
        {
            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.GetAsync($"https://us-restaurant-menus.p.rapidapi.com/restaurants/search?distance={searchRadius}&lat={coordinates.userLatitude}&page=1&lon={coordinates.userLongitude}&q={preferences}")
            //.header("X-RapidAPI-Host", "us-restaurant-menus.p.rapidapi.com")
            //.header("X-RapidAPI-Key", $"{APIKey.rapidAPIKey}");

            Task<HttpResponse<NearbyRestaurants>> response = Unirest.get($"https://us-restaurant-menus.p.rapidapi.com/restaurants/search?distance={searchRadius}&lat={coordinates.userLatitude}&page=1&lon={coordinates.userLongitude}&q={preferences}")
            .header("X-RapidAPI-Host", "us-restaurant-menus.p.rapidapi.com")
            .header("X-RapidAPI-Key", $"{APIKey.rapidAPIKey}")
            .asJsonAsync<NearbyRestaurants>();

            if (response.IsCompletedSuccessfully)
            {
                string jsonResult = response.ToString();
                var restaurantResults = JsonConvert.DeserializeObject<NearbyRestaurants>(jsonResult);
                return restaurantResults;
            }

            return null;



        }
    }
}
