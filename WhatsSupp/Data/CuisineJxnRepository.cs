using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Contracts;
using WhatsSupp.Models;

namespace WhatsSupp.Data
{
    public class CuisineJxnRepository : RepositoryBase<CuisineJxn>, ICuisineJxnRepository
    {
        public CuisineJxnRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
