using CarrerTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerTrack.Data.EntityConfig
{
    public class ArticleConfiguration : EntityTypeConfiguration<Article>
    {
        public ArticleConfiguration()
        {
            HasKey(c => c.ArticleId);

            Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Link)
                .IsRequired()
                .HasMaxLength(300);

            Property(c => c.Source)
               .IsOptional()
               .HasMaxLength(70);

            Property(c => c.IsRead)
                .IsRequired();

            Property(c => c.Notes)
               .IsOptional()
               .HasMaxLength(1000);
        }
    }
}
