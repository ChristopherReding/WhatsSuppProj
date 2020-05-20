using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Contracts;
using WhatsSupp.Models;

namespace WhatsSupp.Data
{
    public class PotentialMatchesRepository : RepositoryBase<PotentialMatch>, IPotentialMatchRepository
    {
        public PotentialMatchesRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
