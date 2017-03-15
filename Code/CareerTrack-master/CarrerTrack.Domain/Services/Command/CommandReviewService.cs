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
    public class CommandReviewService : CommandServiceBase<Review>, ICommandReviewService
    {
        private readonly ICommandReviewRepository _commandRepository;

        public CommandReviewService(ICommandReviewRepository commandRepository)
            : base(commandRepository)
        {
            _commandRepository = commandRepository;
        }
    }
}
