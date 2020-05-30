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

        void UpdateMatch(PotentialMatch potentialMatch);

        Task<List<PotentialMatch>> GetAllTodaysPotentialMatches(int? dinerId);
        Task<List<PotentialMatch>> GetAllMatches(int? dinerId1, int? dinerId2);
        Task<PotentialMatch> GetOneToMatch(int? dinerId1);
        Task<PotentialMatch> GetOneToMatch(int? dinerId1, int? dinerId2);
        Task<PotentialMatch> FindPotentialMatchByMatchId(int? matchId);
        Task<PotentialMatch> FindPotentialMatchByRestaurantId(int? restaurantId);
    }
}
