using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    public class UserTopicConfiguration : IEntityTypeConfiguration<UserTopic>
    {
        public void Configure(EntityTypeBuilder<UserTopic> builder)
        {
            // Composite key configuration
            builder.HasKey(ut => new { ut.UserId, ut.TopicId });

            // User relationship
            builder.HasOne(ut => ut.User)
                   .WithMany(u => u.UserTopics)
                   .HasForeignKey(ut => ut.UserId);

            // Topic relationship
            builder.HasOne(ut => ut.Topic)
                   .WithMany(t => t.UserTopics)
                   .HasForeignKey(ut => ut.TopicId);
        }
    }
}
