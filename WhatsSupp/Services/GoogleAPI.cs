using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WhatsSupp.Contracts;

namespace WhatsSupp.Services
{
    public class GoogleAPI : IGoogleAPIRepository
    {
        public GoogleAPI()
        {
        }

        public async Task<Geolocation> GetGeolocation()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync($"https://www.googleapis.com/geolocation/v1/geolocate?key={APIKey.googleAPIKey}", null);
            Geolocation coordinates = new Geolocation();
            if(response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                JObject jobject = JObject.Parse(json);
                double latitude = (double)jobject["location"]["lat"];
                double longitude = (double)jobject["location"]["lng"];                
                coordinates.userLatitude = latitude;
                coordinates.userLongitude = longitude;
            }
            return coordinates;
        }

        //public async Task<NearbyRestaurants> GetNearbyRestaurants(double radiuskm, Geolocation coordinates, string keyword)
        //{
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.GetAsync($"https://maps.googleapis.com/maps/api/place/nearbysearch/json?" +
        //        $"radius={radiuskm}&" +
        //        $"location={coordinates.userLatitude},{coordinates.userLongitude}&" +
        //        $"type=restaurant&" +
        //        $"keyword={keyword}&" +
        //        $"key={APIKey.googleAPIKey}");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string jsonResult = await response.Content.ReadAsStringAsync();
        //        return JsonConvert.DeserializeObject<NearbyRestaurants>(jsonResult);
        //    }
        //    return null;
        //}

        //public async Task<NearbyRestaurants> GetNearbyRestaurants(double radiuskm, Geolocation coordinates)
        //{
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.GetAsync($"https://maps.googleapis.com/maps/api/place/nearbysearch/json?" +
        //        $"radius={radiuskm}&" +
        //        $"location={coordinates.userLatitude},{coordinates.userLongitude}&" +
        //        $"type=restaurant&" +                
        //        $"key={APIKey.googleAPIKey}");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string jsonResult = await response.Content.ReadAsStringAsync();
        //        return JsonConvert.DeserializeObject<NearbyRestaurants>(jsonResult);
        //    }
        //    return null;
        //}
    }

}
