using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Models;

namespace WhatsSupp.Contracts
{
    public interface IPrelimRestaurantResultsRepository : IRepositoryBase<PrelimRestaurantResults>
    {
        void CreatePrelim(PrelimRestaurantResults prelim);
        void DeletePrelim(PrelimRestaurantResults prelim);
        Task<List<PrelimRestaurantResults>> GetAllPrelims(int? dinerId);
    }
}
