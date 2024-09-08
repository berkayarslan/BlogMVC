using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Domain.Entities;
    using Microsoft.AspNetCore.Identity;
    using Infrastructure.Configurations.Infrastructure.Configurations;

    public class BlogDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<ArticleTopic> ArticleTopics { get; set; }
        public DbSet<UserTopic> UserTopics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);


            // Seed data için idler
            var technologyTopicId = Guid.NewGuid();
            var scienceTopicId = Guid.NewGuid();
            var firstArticleId = Guid.NewGuid();
            var secondArticleId = Guid.NewGuid();
            var authorId = Guid.NewGuid();

            // Topic Seed Data
            modelBuilder.Entity<Topic>().HasData(
                new Topic { Id = technologyTopicId, Name = "Technology" },
                new Topic { Id = scienceTopicId, Name = "Science" }
            );

            // User Seed Data (Admin kullanıcı)
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = authorId,
                    UserName = "admin@blog.com",
                    FirstName = "Admin",
                    LastName = "admin",
                    NormalizedUserName = "ADMIN@BLOG.COM",
                    Email = "admin@blog.com",
                    NormalizedEmail = "ADMIN@BLOG.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin123!"),
                    SecurityStamp = string.Empty
                }
            );

            // Article Seed Data
            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = firstArticleId,
                    Title = "The Future of AI",
                    Content = "Artificial Intelligence (AI) is transforming industries...",
                    CreatedAt = DateTime.UtcNow,
                    AuthorId = authorId
                },
                new Article
                {
                    Id = secondArticleId,
                    Title = "Advances in Medicine",
                    Content = "The medical field is rapidly evolving with new technologies...",
                    CreatedAt = DateTime.UtcNow,
                    AuthorId = authorId
                }
            );

            // ArticleTopic Seed Data
            modelBuilder.Entity<ArticleTopic>().HasData(
                new ArticleTopic
                {
                    ArticleId = firstArticleId, // ArticleId, Article tablosunda mevcut
                    TopicId = technologyTopicId // TopicId, Topic tablosunda mevcut
                },
                new ArticleTopic
                {
                    ArticleId = secondArticleId, // ArticleId, Article tablosunda mevcut
                    TopicId = scienceTopicId // TopicId, Topic tablosunda mevcut
                }
            );
        }
    }
}
