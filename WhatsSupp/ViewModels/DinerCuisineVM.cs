using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Models;

namespace WhatsSupp.ViewModels
{
    public class DinerCuisineVM
    {
        public List<Cuisine> Cuisines { get; set; }
        public Diner Diner { get; set; }
    }
}
