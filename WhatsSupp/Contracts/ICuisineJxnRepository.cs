using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Models;

namespace WhatsSupp.Contracts
{
    public interface ICuisineJxnRepository : IRepositoryBase<CuisineJxn>
    {
        void CreatePreference(CuisineJxn preference);
        void RemovePreference(CuisineJxn preference);
        Task<bool> PreferenceExists(Cuisine cuisine, Diner diner);
    }
}
