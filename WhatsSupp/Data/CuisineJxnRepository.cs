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
        public bool PreferenceExists(Cuisine cuisine, Diner diner)
        {
            var result = FindByCondition(p => p.DinerId == diner.DinerId && p.CuisineId == cuisine.CuisineId);
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
