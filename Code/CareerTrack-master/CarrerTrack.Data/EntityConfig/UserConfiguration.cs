using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.EntityConfig
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(c => c.UserId);

            Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.MiddleName)
                .IsOptional()
                .HasMaxLength(50);

            Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Password)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.PasswordSalt)
                 .IsRequired()
                 .HasMaxLength(150);

            Property(c => c.DateRegistered)
                .IsRequired();

            Property(c => c.IsActive)
                .IsRequired();
        }
    }
}
