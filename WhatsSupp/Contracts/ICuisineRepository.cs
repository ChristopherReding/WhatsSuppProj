﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsSupp.Models;

namespace WhatsSupp.Contracts
{
    public interface ICuisineRepository : IRepositoryBase<Cuisine>
    {
        Task<List<int>> GetAllCuisineIds();
    }
}
