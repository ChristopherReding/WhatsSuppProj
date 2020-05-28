using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsSupp.Models
{
    public class PotentialMatch
    {
        [Key]
        public int MatchId { get; set; }
        
        [ForeignKey("Diner 1")]
        public int? Diner1Id { get; set; }
        public Diner Diner1 { get; set; }
        
        [ForeignKey("Diner 2")]
        public int Diner2Id { get; set; }
        public Diner Diner2 { get; set; }

        public string RestaurantName { get; set; }        
        public string RestaurantAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public int RestaurantId { get; set; }
        public string PriceRange { get; set; }
        public string PhoneNumber { get; set; }
        public string Cuisines { get; set; }
        public bool? Diner1Approved { get; set; }
        public bool? Diner2Approved { get; set; }
    }
}
