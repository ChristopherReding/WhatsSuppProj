using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsSupp.Models
{
    public class Cuisine
    {
        [Key]
        public int CuisineId { get; set; }
        public string CuisineName { get; set; }
        [NotMapped]
        public bool? Selected { get; set; }
    }
}
