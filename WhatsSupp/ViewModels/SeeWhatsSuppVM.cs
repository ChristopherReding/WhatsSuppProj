using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Models;

namespace WhatsSupp.ViewModels
{
    public class SeeWhatsSuppVM
    {
        public Diner Diner { get; set; }
        public Diner Diner2 { get; set; }
        public PotentialMatch PotentialMatch {get;set;}
        public bool Chosen { get; set; }
        public List<PotentialMatch> Matches { get; set; }
    }
}
