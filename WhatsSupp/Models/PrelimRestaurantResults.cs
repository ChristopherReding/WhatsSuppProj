using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsSupp.Models
{
    public class PrelimRestaurantResults
    {
        [Key]
        public int PrelimResultId { get; set; }

        [ForeignKey("Diner 1")]
        public int? Diner1Id { get; set; }
        public Diner Diner1 { get; set; }
    

        public string RestaurantName { get; set; }
        public int? Rating { get; set; }
        public string RestaurantAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public string RestaurantId { get; set; }
    }
}
