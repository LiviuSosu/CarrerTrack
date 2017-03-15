using CarrerTrack.Domain.Entities;
using CarrerTrack.Domain.Interfaces.Read;
using CarrerTrack.Domain.Interfaces.Read.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Services.Read
{
    public class ReadInterviewQuestionService : ReadServiceBase<InterviewQuestion>, IReadInterviewQuestionService
    {
        private readonly IReadInterviewQuestionRepository _readRepository;

        public ReadInterviewQuestionService(IReadInterviewQuestionRepository readRepository)
            :base(readRepository)
        {
            _readRepository = readRepository;
        }
    }
}
