using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Models;

namespace WhatsSupp.Contracts
{
    public interface IDinerRepository : IRepositoryBase<Diner>
    {
        void CreateDiner(Diner diner);
        void DeleteDiner(Diner diner);
        void EditDiner(Diner diner);
        Task<Diner> FindDiner(string userId);
        Task<Diner> FindDinerByDinerId(int? id);
        Task<Diner> FindDinerByEmail(string email);
    }
}
