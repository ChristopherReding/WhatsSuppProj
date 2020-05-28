using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Contracts;
using WhatsSupp.Models;
using WhatsSupp.Services;

namespace WhatsSupp.Data
{
    public class PotentialMatchesRepository : RepositoryBase<PotentialMatch>, IPotentialMatchRepository
    {
        public PotentialMatchesRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public void CreateMatch(PotentialMatch potentialMatch) => Create(potentialMatch);
        public void DeleteMatch(PotentialMatch potentialMatch) => Delete(potentialMatch);
        public async Task<List<PotentialMatch>> GetAllMatches(int? dinerId1, int? dinerId2)
        {
            DateTime now = DateTime.Now;
            var results = await FindByCondition(p => p.Diner1Id == dinerId1 && p.Diner2Id == dinerId2 && p.TimeStamp.DayOfYear == now.DayOfYear);
            var listOfMatches = results.ToList();
            return listOfMatches;
        }
                  
        

    }
}
