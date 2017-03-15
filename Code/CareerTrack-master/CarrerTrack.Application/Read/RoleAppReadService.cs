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
    public class RoleAppReadService : AppReadServiceBase<Role>, IAppReadRoleService
    {
        private readonly IReadRoleService _commandRoleService;

        public RoleAppReadService(IReadRoleService commandRoleService)
            : base(commandRoleService)
        {
            _commandRoleService = commandRoleService;
        }

        IEnumerable<Role> IAppReadRoleService.GetUserRoles(int userId)
        {
            return _commandRoleService.GetUserRoles(userId);
        }
    }
}
