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

        public async Task<T> Get<T>(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("X-RapidAPI-Host", "us-restaurant-menus.p.rapidapi.com");
                client.DefaultRequestHeaders.TryAddWithoutValidation("X-RapidAPI-Key", $"{APIKey.rapidAPIKey}");
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public async Task<NearbyRestaurants> GetNearbyRestaurants(Geolocation coordinates, double searchRadius, string preferences)
        {
            string url = ($"https://us-restaurant-menus.p.rapidapi.com/restaurants/search?distance={searchRadius}&lat={coordinates.userLatitude}&page=1&lon={coordinates.userLongitude}&q={preferences}");
            var result = await Get<NearbyRestaurants>(url);
            return result;
        }
    }
}
