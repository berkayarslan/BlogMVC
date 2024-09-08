using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<IEnumerable<Article>> GetArticlesByAuthorIdAsync(Guid authorId);
        Task<IEnumerable<Article>> GetMostReadArticlesAsync(int count);
    }

}
