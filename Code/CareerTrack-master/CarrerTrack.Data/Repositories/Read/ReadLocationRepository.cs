using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.Repositories.Read
{
    public class ReadLocationRepository : ReadRepositoryBase<Location>, IReadLocationRepository
    {
        public IEnumerable<Location> GetUserLocations(int userId)
        {
            return db.Locations.Where(article => article.UserId == userId);
        }
    }
}