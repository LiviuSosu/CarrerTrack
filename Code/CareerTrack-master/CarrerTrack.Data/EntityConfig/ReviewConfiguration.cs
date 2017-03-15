using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.EntityConfig
{
    public class ReviewConfiguration : EntityTypeConfiguration<Review>
    {
        public ReviewConfiguration()
        {
            HasKey(r => r.Id);

            Property(r => r.Content)
                .IsRequired()
                .HasMaxLength(1000);

            Property(r => r.Source)
                .IsRequired()
                .HasMaxLength(350);

            Property(r => r.UserNotes)
                .IsOptional()
                .HasMaxLength(1000);
        }
    }
}
