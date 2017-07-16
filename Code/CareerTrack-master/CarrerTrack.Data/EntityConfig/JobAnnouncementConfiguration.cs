using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.EntityConfig
{
    public class JobAnnouncementConfiguration : EntityTypeConfiguration<JobAnnouncement>
    {
        public JobAnnouncementConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.RoleId)
                .IsRequired();

            Property(c => c.Contact)
                .IsOptional()
                .HasMaxLength(300);

            Property(c => c.Content)
               .IsOptional()
               .HasMaxLength(8000);

            Property(c => c.LocationId)
                .IsRequired();

            Property(c => c.Rewards)
               .IsOptional();

            Property(c => c.Source)
               .IsRequired()
               .HasMaxLength(300);

            Property(c => c.Rewards)
               .IsOptional()
               .HasMaxLength(8000);

            Property(c => c.RoleId)
               .IsRequired();

            Property(c => c.UserId)
               .IsRequired();
        }
    }
}
