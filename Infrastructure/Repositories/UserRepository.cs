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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BlogDbContext context) : base(context)
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));

            var user = await _dbSet.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                throw new KeyNotFoundException("User not found");

            // Kontrol ekleyin: Eğer veritabanındaki email sütunu null olabilir ve bu null durumu kontrol etmek isterseniz:
            if (string.IsNullOrEmpty(user.Email))
                throw new InvalidOperationException("The user's email is null.");

            return user;
        }

        public async Task<User> GetByIdWithIncludesAsync(Guid id)
        {
            return await _context.Users
        .Include(u => u.Articles)
        .Include(u => u.UserTopics)
            .ThenInclude(ut => ut.Topic)
        .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
