using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.EntityConfig
{
    public class IntreviewQuestionConfiguration : EntityTypeConfiguration<InterviewQuestion>
    {
        public IntreviewQuestionConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.AnswerContent)
                .IsOptional()
                .HasMaxLength(1000);

            Property(c => c.QuestionContent)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
