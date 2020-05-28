using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Services;

namespace WhatsSupp.Contracts
{
    public interface IRapidAPIRepository
    {
        Task<T> Get<T>(string url);
        Task<NearbyRestaurants> GetNearbyRestaurants(Geolocation coordinates, double searchRadius, string preferences);
    }
}
