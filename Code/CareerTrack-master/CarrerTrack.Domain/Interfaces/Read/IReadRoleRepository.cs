using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Interfaces.Read
{
    public interface IReadRoleRepository : IReadRepositoryBase<Role>
    {
        /// <summary>
        /// Get all Roles for a given user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Role> GetUserRoles(int userId);
    }
}
