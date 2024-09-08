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
        public class ArticleTopicConfiguration : IEntityTypeConfiguration<ArticleTopic>
        {
            public void Configure(EntityTypeBuilder<ArticleTopic> builder)
            {
                // Bileşik anahtar tanımlaması
                builder.HasKey(at => new { at.ArticleId, at.TopicId });

                // İlişkilerin tanımlanması
                builder.HasOne(at => at.Article)
                       .WithMany(a => a.ArticleTopics)
                       .HasForeignKey(at => at.ArticleId);

                builder.HasOne(at => at.Topic)
                       .WithMany(t => t.ArticleTopics)
                       .HasForeignKey(at => at.TopicId);

                // Seed data ekleme (ID'ler Articles ve Topics tablolarındaki ID'lerle eşleşmeli)
                builder.HasData(
                    new ArticleTopic
                    {
                        ArticleId = Guid.Parse("E15D1D64-6E7C-4D58-B5E9-AF53EECF8581"),
                        TopicId = Guid.Parse("8B9DC5E4-7B3F-4D3A-B69D-72772E591FE1")
                    },
                    new ArticleTopic
                    {
                        ArticleId = Guid.Parse("77A2BBE4-2FE9-4A9C-9059-3C9AC0E448BA"),
                        TopicId = Guid.Parse("3FD34475-DF54-45B8-9733-1C42CBE9F8EF")
                    }
                );
            }
        }
    }
}
