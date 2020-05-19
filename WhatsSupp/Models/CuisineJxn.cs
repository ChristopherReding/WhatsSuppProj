using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsSupp.Models
{
    public class CuisineJxn
    {
        [Key]
        public int CuisineJxnId { get; set; }
        [ForeignKey("Diner")]
        public int? DinerId { get; set; }
        public Diner Diner { get; set; }
        [ForeignKey("Cuisine")]
        public int? CuisineId { get; set; }
        public Cuisine Cuisine { get; set; }

    }
}
