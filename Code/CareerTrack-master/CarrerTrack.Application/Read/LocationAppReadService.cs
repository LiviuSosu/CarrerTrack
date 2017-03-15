using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Read
{
    public class LocationAppReadService : AppReadServiceBase<Location>, IAppReadLocationService
    {
        private readonly IReadLocationService _commandLocationService;

        public LocationAppReadService(IReadLocationService commandLocationService)
            : base(commandLocationService)
        {
            _commandLocationService = commandLocationService;
        }

        IEnumerable<Location> IAppReadLocationService.GetUserLocations(int userId)
        {
            return _commandLocationService.GetUserLocations(userId);
        }
    }
}
