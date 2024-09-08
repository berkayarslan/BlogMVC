using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserTopicRepository : IUserTopicRepository
    {
        private readonly BlogDbContext _context;

        public UserTopicRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Guid>> GetFollowedTopicsByUserIdAsync(Guid userId)
        {
            return await _context.UserTopics
                .Where(ut => ut.UserId == userId)
                .Select(ut => ut.TopicId)
                .ToListAsync();
        }

        public async Task FollowTopicsAsync(Guid userId, IEnumerable<Guid> topicIds)
        {
            // Var olan takipleri sil
            var existingFollowedTopics = _context.UserTopics.Where(ut => ut.UserId == userId);
            _context.UserTopics.RemoveRange(existingFollowedTopics);

            // Yeni takip edilen konuları ekle
            var newFollowedTopics = topicIds.Select(topicId => new UserTopic
            {
                UserId = userId,
                TopicId = topicId
            });

            await _context.UserTopics.AddRangeAsync(newFollowedTopics);
        }
    }
}
