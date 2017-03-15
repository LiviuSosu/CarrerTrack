using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.EntityConfig
{
    public class LocationConfiguration : EntityTypeConfiguration<Location>
    {
        public LocationConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.City)
                .IsRequired()
                .HasMaxLength(30);

            Property(c => c.Details)
                .IsOptional()
                .HasMaxLength(1000);
        }
    }
}
