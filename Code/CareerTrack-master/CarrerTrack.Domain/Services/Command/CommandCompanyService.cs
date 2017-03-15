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
    public class CommandCompanyService : CommandServiceBase<Company>, ICommandCompanyService
    {
        private readonly ICommandCompanyRepository _commandRepository;

        public CommandCompanyService(ICommandCompanyRepository commandRepository)
            : base(commandRepository)
        {
            _commandRepository = commandRepository;
        }
    }
}
