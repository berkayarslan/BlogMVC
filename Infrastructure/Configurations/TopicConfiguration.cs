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
        public class TopicConfiguration : IEntityTypeConfiguration<Topic>
        {
            public void Configure(EntityTypeBuilder<Topic> builder)
            {
                builder.HasKey(t => t.Id);
                builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
                builder.HasMany(t => t.ArticleTopics)
                       .WithOne(at => at.Topic)
                       .HasForeignKey(at => at.TopicId);
            }
        }
    }

}
