using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.EntityConfig
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            HasKey(r => r.Id);

            Property(r => r.BookTitle)
                .IsRequired()
                .HasMaxLength(150);

            Property(r => r.Author)
                .IsOptional()
                .HasMaxLength(150);

            Property(r => r.Status)
                .IsRequired()
                .HasMaxLength(1000);

            Property(r => r.Description)
              .IsOptional()
              .HasMaxLength(1000);

            Property(r => r.ContentType)
              .IsOptional();

            Property(r => r.Content)
                .IsOptional();
        }
    }
}
