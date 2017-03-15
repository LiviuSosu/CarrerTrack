﻿using CarrerTrack.Application.Read.Interface;
using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Application.Read
{
    public class InterviewQuestionAppReadService : AppReadServiceBase<InterviewQuestion>, IAppReadInterviewQuestionService
    {
        private readonly IReadInterviewQuestionService _commandInterviewQuestionService;

        public InterviewQuestionAppReadService(IReadInterviewQuestionService commandInterviewQuestionService)
            : base(commandInterviewQuestionService)
        {
            _commandInterviewQuestionService = commandInterviewQuestionService;
        }
    }
}
