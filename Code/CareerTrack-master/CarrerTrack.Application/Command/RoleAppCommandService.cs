using CarrerTrack.Application.Command.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Command.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Command
{
    public class RoleAppCommandService : AppCommandServiceBase<Role>, IAppCommandRoleService
    {
        private readonly ICommandRoleService _commandRoleService;

        public RoleAppCommandService(ICommandRoleService commandRoleService)
            :base(commandRoleService)
        {
            _commandRoleService = commandRoleService;
        }
    }
}
