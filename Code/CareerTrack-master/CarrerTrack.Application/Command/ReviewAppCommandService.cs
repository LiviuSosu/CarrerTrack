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
    public class ReviewAppCommandService : AppCommandServiceBase<Review>, IAppCommandReviewService
    {
        private readonly ICommandReviewService _commandReviewService;

        public ReviewAppCommandService(ICommandReviewService commandReviewService)
            : base(commandReviewService)
        {
            _commandReviewService = commandReviewService;
        }
    }
}
