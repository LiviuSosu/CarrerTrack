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
    public class InterviewQuestionAppCommandService : AppCommandServiceBase<InterviewQuestion>, IAppCommandInterviewQuestionService
    {
        private readonly ICommandInterviewQuestionService _commandInterviewQuestionService;

        public InterviewQuestionAppCommandService(ICommandInterviewQuestionService commandInterviewQuestionService)
            :base(commandInterviewQuestionService)
        {
            _commandInterviewQuestionService = commandInterviewQuestionService;
        }
    }
}