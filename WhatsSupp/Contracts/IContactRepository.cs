using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Models;

namespace WhatsSupp.Contracts
{
    public interface IContactRepository: IRepositoryBase<Contact>
    {
        void CreateContact(Contact contact);
        void RemoveContact(Contact contact);

        Task<bool> ContactExists(Diner diner1, Diner diner2);
        Task<List<int?>> GetContactIds(int? dinerId);
    }
}
