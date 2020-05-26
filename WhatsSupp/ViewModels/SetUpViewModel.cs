using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Models;
using WhatsSupp.Services;

namespace WhatsSupp.ViewModels
{
    public class SetUpViewModel
    {
        public Diner Diner { get; set; }
        public Diner Diner2 { get; set; }
        public Geolocation startingCoordinates { get; set; }
        public double searchRadius { get; set; }
        public string preferences { get; set; }
        public NearbyRestaurants nearbyRestaurants { get; set; }
    }
}
