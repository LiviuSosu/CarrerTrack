using CarrerTrack.Domain.Entities;
using System.Collections.Generic;

namespace CarrerTrack.Application.Read.Interface
{
    public interface IAppReadRoleService :  IAppReadServiceBase<Role>
    {
        IEnumerable<Role> GetUserRoles(int userId);
    }
}
