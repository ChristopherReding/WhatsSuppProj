using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Models;
using WhatsSupp.Services;

namespace WhatsSupp.Contracts
{
    public interface IPotentialMatchRepository : IRepositoryBase<PotentialMatch>
    {
        void CreateMatch(PotentialMatch potentialMatch);
        void DeleteMatch(PotentialMatch potentialMatch);

        
        Task<List<PotentialMatch>> GetAllMatches(int? dinerId1, int? dinerId2);
        Task<PotentialMatch> GetOneMatch(int? dinerId1);
        Task<PotentialMatch> GetOneMatch(int? dinerId1, int? dinerId2);
    }
}
