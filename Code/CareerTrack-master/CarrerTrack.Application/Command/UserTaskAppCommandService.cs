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
    public class UserTaskAppCommandService : AppCommandServiceBase<UserTask>, IAppCommandUserTaskService
    {
        private readonly ICommandUserTaskService _commandUserTaskService;

        public UserTaskAppCommandService(ICommandUserTaskService commandUserTaskService)
            :base(commandUserTaskService)
        {
            _commandUserTaskService = commandUserTaskService;
        }
    }
}
