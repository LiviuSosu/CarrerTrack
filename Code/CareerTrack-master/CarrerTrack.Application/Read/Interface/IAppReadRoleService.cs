using CarrerTrack.Domain.Entities;
using System.Collections.Generic;

namespace CarrerTrack.Application.Read.Interface
{
    public interface IAppReadRoleService :  IAppReadServiceBase<Role>
    {
        /// <summary>
        /// Get all Roles for a given user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Role> GetUserRoles(int userId);
    }
}
