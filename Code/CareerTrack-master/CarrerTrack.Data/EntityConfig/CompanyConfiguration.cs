using CarrerTrack.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CarrerTrack.Data.EntityConfig
{
    public class CompanyConfiguration : EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            HasKey(r => r.CompanyId);

            Property(r => r.CompanyName)
                .IsRequired()
                .HasMaxLength(150);

            Property(r => r.Size)
                .IsRequired()
                .HasMaxLength(150);

            Property(r => r.GeneralDescription)
                .IsOptional()
                .HasMaxLength(1000);

            Property(r => r.Link)
              .IsOptional()
              .HasMaxLength(500);
        }
    }
}
