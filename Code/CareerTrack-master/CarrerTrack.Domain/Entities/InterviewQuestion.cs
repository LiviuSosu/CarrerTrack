using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Domain.Entities
{
    public class InterviewQuestion
    {
        public int Id { get; set; }

        public string QuestionContent { get; set; }
        public string AnswerContent { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
