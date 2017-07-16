using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.EntityConfig
{
    public class SkillConfiguration: EntityTypeConfiguration<Skill>
    {
        public SkillConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Description)
              .IsOptional()
              .HasMaxLength(1000);
        }
    }
}
