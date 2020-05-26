using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WhatsSupp.Services
{


    public class NearbyRestaurants
    {
        public Result result { get; set; }
    }

    public class Result
    {
        public int totalResults { get; set; }
        public Datum[] data { get; set; }
        public int numResults { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
        public bool morePages { get; set; }
    }

    public class Datum
    {
        public Geo geo { get; set; }
        public string hours { get; set; }
        public Address address { get; set; }
        public string restaurant_phone { get; set; }
        public int restaurant_id { get; set; }
        public string price_range { get; set; }
        public object[] menus { get; set; }
        public int price_range_100 { get; set; }
        public string[] cuisines { get; set; }
        public string restaurant_name { get; set; }
    }

    public class Geo
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }

    public class Address
    {
        public string city { get; set; }
        public string formatted { get; set; }
        public string street { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
    }
}