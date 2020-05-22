using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Contracts;
using WhatsSupp.Models;

namespace WhatsSupp.Data
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public void CreateContact(Contact contact) => Create(contact);
        public void RemoveContact(Contact contact) => Delete(contact);
        

        public async Task<bool> ContactExists(Diner diner1, Diner diner2)
        {
            var result = await FindByCondition(p =>
                p.Diner1Id == diner1.DinerId && p.Diner2Id == diner2.DinerId
                || p.Diner2Id == diner1.DinerId && p.Diner1Id == diner2.DinerId);
            var contact = result.FirstOrDefault();
            if(contact != null)
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
