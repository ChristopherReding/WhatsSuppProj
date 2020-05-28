using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsSupp.RootObjects
{

    public class Menu
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
        public Address address { get; set; }
        public string[] cuisines { get; set; }
        public Geo geo { get; set; }
        public int item_id { get; set; }
        public string menu_item_description { get; set; }
        public string menu_item_name { get; set; }
        public object[] menu_item_pricing { get; set; }
        public string price_range { get; set; }
        public string restaurant_hours { get; set; }
        public int restaurant_id { get; set; }
        public string restaurant_name { get; set; }
        public string restaurant_phone { get; set; }
        public string subsection { get; set; }
        public string subsection_description { get; set; }
    }

    public class Address
    {
        public string city { get; set; }
        public string formatted { get; set; }
        public string postal_code { get; set; }
        public string state { get; set; }
        public string street { get; set; }
    }

    public class Geo
    {
        public float lat { get; set; }
        public float lon { get; set; }
    }
}
