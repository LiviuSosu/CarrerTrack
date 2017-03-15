using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.EntityConfig
{
    public class UserTaskConfiguration : EntityTypeConfiguration<UserTask>
    {
        public UserTaskConfiguration()
        {
            HasKey(ut=>ut.Id);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Description)
                .IsOptional()
                .HasMaxLength(500);

            Property(c => c.ToComplete)
                .IsOptional()
                .HasColumnType("datetime");

            Property(c => c.DateAdded).
                HasColumnType("datetime");
        }
    }
}
