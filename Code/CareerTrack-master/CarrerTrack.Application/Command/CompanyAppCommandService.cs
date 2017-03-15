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
    public class CompanyAppCommandService : AppCommandServiceBase<Company>, IAppCommandCompanyService
    {
        private readonly ICommandCompanyService _commandCompanyService;

        public CompanyAppCommandService(ICommandCompanyService commandCompanyService)
            :base(commandCompanyService)
        {
            _commandCompanyService = commandCompanyService;
        }
    }
}
