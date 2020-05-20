using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Contracts;
using WhatsSupp.Data;

namespace WhatsSupp
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _context;
        private IContactRepository _contact;
        private ICuisineRepository _cuisine;
        private ICuisineJxnRepository _cuisineJxn;
        private IDinerRepository _diner;
        private IPotentialMatchRepository _potentialMatch;
        
        public IContactRepository Contact
        {
            get
            {
                if(_contact == null)
                {
                    _contact = new ContactRepository(_context);
                }
                return _contact;
            }
        }
        public ICuisineRepository Cuisine
        {
            get
            {
                if(_cuisine == null)
                {
                    _cuisine = new CuisineRepository(_context);
                }
                return _cuisine;
            }
        }
        public ICuisineJxnRepository CuisineJxn
        {
            get
            {
                if(_cuisineJxn == null)
                {
                    _cuisineJxn = new CuisineJxnRepository(_context);
                }
                return _cuisineJxn;
            }
        }
        public IDinerRepository Diner
        {
            get
            {
                if (_diner == null)
                {
                    _diner = new DinerRepository(_context);
                }
                return _diner;
            }
        }
        public IPotentialMatchRepository PotentialMatch
        {
            get
            {
                if(_potentialMatch == null)
                {
                    _potentialMatch = new PotentialMatchesRepository(_context);
                }
                return _potentialMatch;
            }
        }


        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
