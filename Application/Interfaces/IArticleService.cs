using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.ArticleDTOs;

namespace Application.Interfaces
{
    public interface IArticleService
    {
        Task<Guid> CreateArticleAsync(CreateArticleDto articleDto);
        Task UpdateArticleAsync(ArticleDto articleDto);
        Task DeleteArticleAsync(Guid articleDto);
        Task<IEnumerable<ArticleDto>> GetArticlesByUserIdAsync(Guid userId);
        Task<ArticleDto> GetArticleByIdAsync(Guid articleId);
        Task<IEnumerable<ArticleDto>> GetMostReadArticlesAsync(int count);
    }
}
