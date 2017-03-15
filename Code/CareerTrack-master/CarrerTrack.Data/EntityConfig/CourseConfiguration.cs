using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.EntityConfig
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Source)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Description)
               .IsOptional()
               .HasMaxLength(1000);

            Property(c => c.Link)
                .IsOptional()
                .HasMaxLength(500);

            Property(c => c.Status)
               .HasMaxLength(150);

            Property(c => c.Notes)
               .IsOptional()
               .HasMaxLength(1000);
        }
    }
}
