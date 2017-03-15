using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.EntityConfig
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            HasKey(r => r.Id);

            Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(150);

            Property(r => r.Description)
                .IsOptional()
                .HasMaxLength(1000);
        }
    }
}
