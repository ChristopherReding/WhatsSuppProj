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

        public void CreateDiner(Diner diner) => Create(diner);
        public void DeleteDiner(Diner diner) => Delete(diner);
        public void EditDiner(Diner diner) => Update(diner);
        public async Task<Diner> FindDiner(string userId)
        {
            var result = await FindByCondition(p => p.IdentityUserId == userId);
            var currentUser = result.SingleOrDefault();
            return currentUser;                
        }
        public async Task<Diner> FindDinerByDinerId(int? id)
        {
            var result = await FindByCondition(p => p.DinerId == id);
            var diner = result.SingleOrDefault();
            return diner;
        }
        public async Task<Diner> FindDinerByEmail(string email)
        {
            var result = await FindByCondition(p => p.IdentityUser.Email == email);
            var contact = result.SingleOrDefault();
            return contact;
        }
    }
}
