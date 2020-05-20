using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsSupp.Contracts
{
    public interface IRepositoryWrapper
    { 
        IContactRepository Contact { get; }
        ICuisineRepository Cuisine { get; }
        ICuisineJxnRepository CuisineJxn { get; }
        IDinerRepository Diner { get; }
        IPotentialMatchRepository PotentialMatch { get; }
        void Save();
    }
}
