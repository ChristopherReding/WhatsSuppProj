using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Contracts;
using WhatsSupp.Models;

namespace WhatsSupp.Data
{
    public class PrelimRestaurantResultsRepository : RepositoryBase<PrelimRestaurantResults>, IPrelimRestaurantResultsRepository
    {
        public PrelimRestaurantResultsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public void CreatePrelim(PrelimRestaurantResults prelim) => Create(prelim);
        public void DeletePrelim(PrelimRestaurantResults prelim) => Delete(prelim);
        public async Task<List<PrelimRestaurantResults>> GetAllPrelims(int? dinerId1)
        {
            DateTime now = DateTime.Now;
            var results = await FindByCondition(p => p.Diner1Id == dinerId1&& p.TimeStamp.DayOfYear == now.DayOfYear);
            var listOfPrelims = results.ToList();
            return listOfPrelims;
        }
    }
}
