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
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(BlogDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Article>> GetArticlesByAuthorIdAsync(Guid authorId)
        {
            return await _dbSet
                .Where(article => article.AuthorId == authorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetMostReadArticlesAsync(int count)
        {
            return await _context.Articles
             .OrderByDescending(a => a.ReadCount)
             .Take(count)
             .ToListAsync();
        }
    }
}
