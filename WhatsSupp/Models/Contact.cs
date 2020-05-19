using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsSupp.Models
{
    public class Contact
    {
        [Key]
        public int ContactJxnId { get; set; }
        [ForeignKey("Contact1")]
        public int? Diner1Id { get; set; }
        [ForeignKey("Contact2")]
        public int? Diner2Id { get; set; }
    };
}
