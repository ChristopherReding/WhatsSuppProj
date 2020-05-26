using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Services;

namespace WhatsSupp.Contracts
{
    public interface IGoogleAPIRepository
    {
        Task<Geolocation> GetGeolocation();
        //Task<NearbyRestaurants> GetNearbyRestaurants(double radiuskm, Geolocation coordinates);
        //Task<NearbyRestaurants> GetNearbyRestaurants(double radiuskm, Geolocation coordinates, string keyword);
    }
}
