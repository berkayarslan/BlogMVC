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
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        public TopicRepository(BlogDbContext context) : base(context)
        {
        }

        public async Task<Topic> GetByNameAsync(string name)
        {
            return await _dbSet
               .FirstOrDefaultAsync(t => t.Name == name);
        }

        public async Task<IEnumerable<Topic>> GetTopicsWithArticlesAsync(Guid? topicId = null)
        {
            // Sorguyu başlatın ve ilişkili verileri dahil edin
            var query = _context.Topics
                .Include(t => t.ArticleTopics)
                    .ThenInclude(at => at.Article)
                .AsQueryable();

            // Eğer bir topicId sağlanmışsa, o topicId'ye göre filtreleme yapın
            if (topicId.HasValue)
            {
                query = query.Where(t => t.Id == topicId.Value);
            }

            // Sorguyu çalıştırın ve sonucu döndürün
            return await query.ToListAsync();
        }

    }
}

