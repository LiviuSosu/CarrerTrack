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
    public class SkillAppCommandService : AppCommandServiceBase<Skill>, IAppCommandSkillService
    {
        private readonly ICommandSkillService _commandSkillService;

        public SkillAppCommandService(ICommandSkillService commandSkillService)
            :base(commandSkillService)
        {
            _commandSkillService = commandSkillService;
        }
    }
}
