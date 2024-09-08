using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext _context;

        public UnitOfWork(BlogDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Articles = new ArticleRepository(_context);
            Topics = new TopicRepository(_context);
        }

        public IUserRepository Users { get; private set; }
        public IArticleRepository Articles { get; private set; }
        public ITopicRepository Topics { get; private set; }
        public IUserTopicRepository UserTopics { get; private set; }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
