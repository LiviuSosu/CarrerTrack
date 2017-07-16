﻿using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Interfaces.Read.Services
{
    public interface IReadLocationService : IReadServiceBase<Location>
    {
        /// <summary>
        /// Get all Locantions for the given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Location> GetUserLocations(int userId);
    }
}
