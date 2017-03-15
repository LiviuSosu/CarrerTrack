using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Command;
using CarrerTrack.Domain.Interfaces.Command.Services;

namespace CarrerTrack.Domain.Services.Command
{
    public class CommandRoleService : CommandServiceBase<Role>, ICommandRoleService
    {
        private readonly ICommandRoleRepository _commandRepository;

        public CommandRoleService(ICommandRoleRepository commandRepository)
            : base(commandRepository)
        {
            _commandRepository = commandRepository;
        }
    }
}
