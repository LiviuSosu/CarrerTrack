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
    public class LocationAppCommandService : AppCommandServiceBase<Location>, IAppCommandLocationService
    {
        private readonly ICommandLocationService _commandLocationService;

        public LocationAppCommandService(ICommandLocationService commandLocationService)
            : base(commandLocationService)
        {
            _commandLocationService = commandLocationService;
        }
    }
}