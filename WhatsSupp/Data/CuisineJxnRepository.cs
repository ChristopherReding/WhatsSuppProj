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

        public void CreatePreference(CuisineJxn preference) => Create(preference);
        public void RemovePreference(CuisineJxn preference) => Delete(preference);
        public async Task<bool> PreferenceExists(Cuisine cuisine, Diner diner)
        {
            try
            {
                var result = await FindByCondition(p => cuisine.CuisineId == p.CuisineId && diner.DinerId == p.DinerId);
                var preference = result.SingleOrDefault();
                if (preference != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            
                
          

            

        }
    }
}
