using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsSupp.Models
{
    public class Diner
    {
        [Key]
        public int DinerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public double searchRadius { get; set; }
        [NotMapped]
        public int Diner2Id { get; set; }
        [NotMapped]
        public List<Cuisine> CuisinePreferences { get; set; }
        [NotMapped]
        public List<Diner> Contacts { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
