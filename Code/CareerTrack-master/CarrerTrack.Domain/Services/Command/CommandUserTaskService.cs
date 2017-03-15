using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Command;
using CarrerTrack.Domain.Interfaces.Command.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Services.Command
{
    public class CommandUserTaskService : CommandServiceBase<UserTask>, ICommandUserTaskService
    {
        private readonly ICommandUserTaskRepository _commandRepository;

        public CommandUserTaskService(ICommandUserTaskRepository commandRepository)
            :base(commandRepository)
        {
            _commandRepository = commandRepository;
        }
    }
}
