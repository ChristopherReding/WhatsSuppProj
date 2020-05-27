using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Models;

namespace WhatsSupp.Contracts
{
    public interface IPotentialMatchRepository : IRepositoryBase<PotentialMatch>
    {
        void CreateMatch(PotentialMatch potentialMatch);
        void DeleteMatch(PotentialMatch potentialMatch);

        Task<List<PotentialMatch>> GetAllMatches(int? dinerId1, int? dinerId2);
    }
}
