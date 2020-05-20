using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Contracts;
using WhatsSupp.Models;

namespace WhatsSupp.Data
{
    public class DinerRepository : RepositoryBase<Diner>, IDinerRepository
    {
        public DinerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
