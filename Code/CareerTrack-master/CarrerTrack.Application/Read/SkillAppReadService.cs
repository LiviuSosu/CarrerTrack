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
    public class SkillAppReadService : AppReadServiceBase<Skill>, IAppReadSkillService
    {
        private readonly IReadSkillService _commandSkillService;

        public SkillAppReadService(IReadSkillService commandSkillService)
            :base(commandSkillService)
        {
            _commandSkillService = commandSkillService;
        }
    }
}
