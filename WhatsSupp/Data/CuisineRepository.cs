using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Contracts;
using WhatsSupp.Models;

namespace WhatsSupp.Data
{
    public class CuisineRepository : RepositoryBase<Cuisine>, ICuisineRepository
    {
        public CuisineRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

    }
}
