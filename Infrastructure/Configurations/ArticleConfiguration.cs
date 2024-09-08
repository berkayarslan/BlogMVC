using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Entities;

    namespace Infrastructure.Configurations
    {
        public class ArticleConfiguration : IEntityTypeConfiguration<Article>
        {
            public void Configure(EntityTypeBuilder<Article> builder)
            {
                builder.HasKey(a => a.Id);
                builder.Property(a => a.Title).IsRequired().HasMaxLength(200);
                builder.Property(a => a.Content).IsRequired();
                builder.Property(a => a.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
                builder.HasMany(a => a.ArticleTopics)
                       .WithOne(at => at.Article)
                       .HasForeignKey(at => at.ArticleId);
            }
        }
    }
}
