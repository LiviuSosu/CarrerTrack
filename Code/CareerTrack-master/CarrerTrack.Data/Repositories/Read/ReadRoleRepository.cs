using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read;
using System.Collections.Generic;
using System.Linq;

namespace CarrerTrack.Data.Repositories.Read
{
    public class ReadRoleRepository : ReadRepositoryBase<Role>, IReadRoleRepository
    {
        public IEnumerable<Role> GetUserRoles(int userId)
        {
            return db.Roles.Where(r=>r.UserId==userId);
        }
    }
}
