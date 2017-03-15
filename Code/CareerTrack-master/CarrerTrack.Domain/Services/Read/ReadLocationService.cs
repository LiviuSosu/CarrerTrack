using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read;
using CarrerTrack.Domain.Interfaces.Read.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Services.Read
{
    public class ReadLocationService : ReadServiceBase<Location>, IReadLocationService
    {
        private readonly IReadLocationRepository _readRepository;

        public ReadLocationService(IReadLocationRepository readRepository)
            :base(readRepository)
        {
            _readRepository = readRepository;
        }

        public IEnumerable<Location> GetUserLocations(int userId)
        {
            return _readRepository.GetUserLocations(userId);
        }
    }
}
