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
        Task<List<Cuisine>> ReflectCuisinePreferences(List<Cuisine> allCuisines, Diner diner);
        string preferencesAsString(List<Cuisine> preferedCuisines);
        Task<List<Cuisine>> GetListOfCuisinePreferences(List<Cuisine> allCuisines, Diner diner);
    }
}
