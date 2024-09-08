using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.ArticleDTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public async Task<Guid> CreateArticleAsync(CreateArticleDto articleDto)
        {
            try
            {
                if (articleDto == null) throw new ArgumentNullException(nameof(articleDto), "Article data cannot be null.");

                var article = _mapper.Map<Article>(articleDto);
                article.Id = Guid.NewGuid();
                article.CreatedAt = DateTime.UtcNow;

                // Image Upload işlemi
                if (articleDto.Image != null)
                {
                    var imageUrl = await _fileService.UploadFileAsync(articleDto.Image, "uploads/article_images");
                    article.ImageUrl = imageUrl ?? throw new InvalidOperationException("Image upload failed.");
                }

                article.ArticleTopics = new List<ArticleTopic>();

                var topicNames = articleDto.Topics.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(t => t.Trim())
                                                  .Distinct();

                foreach (var topicName in topicNames)
                {
                    var topic = await _unitOfWork.Topics.GetByNameAsync(topicName);
                    if (topic == null)
                    {
                        topic = new Topic { Id = Guid.NewGuid(), Name = topicName };
                        await _unitOfWork.Topics.AddAsync(topic);
                    }

                    article.ArticleTopics.Add(new ArticleTopic { ArticleId = article.Id, TopicId = topic.Id });
                }

                await _unitOfWork.Articles.AddAsync(article);
                await _unitOfWork.SaveAsync();

                return article.Id;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while creating the article: " + ex.Message);
            }
        }

        public async Task<IEnumerable<ArticleDto>> GetArticlesByUserIdAsync(Guid userId)
        {
            try
            {
                if (userId == Guid.Empty) throw new ArgumentException("User ID cannot be empty.");

                var articles = await _unitOfWork.Articles.GetArticlesByAuthorIdAsync(userId);
                return _mapper.Map<IEnumerable<ArticleDto>>(articles);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving articles by user ID: " + ex.Message);
            }
        }

        public async Task<ArticleDto> GetArticleByIdAsync(Guid articleId)
        {
            try
            {
                if (articleId == Guid.Empty) throw new ArgumentException("Article ID cannot be empty.");

                var article = await _unitOfWork.Articles.GetByIdAsync(articleId);
                if (article == null) throw new KeyNotFoundException("Article not found.");

                return _mapper.Map<ArticleDto>(article);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the article by ID: " + ex.Message);
            }
        }

        public async Task UpdateArticleAsync(ArticleDto articleDto)
        {
            try
            {
                if (articleDto == null) throw new ArgumentNullException(nameof(articleDto), "Article data cannot be null.");

                
                var article = await _unitOfWork.Articles.GetByIdAsync(articleDto.Id);
                if (article == null) throw new KeyNotFoundException("Article not found for updating.");

                
                _mapper.Map(articleDto, article);

               
                article.ArticleTopics.Clear();

                
                if (articleDto.TopicIds != null)
                {
                    foreach (var topicId in articleDto.TopicIds)
                    {
                        article.ArticleTopics.Add(new ArticleTopic { ArticleId = article.Id, TopicId = topicId });
                    }
                }

                
                _unitOfWork.Articles.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException("An error occurred while updating the article: " + ex.Message, ex);
            }
        }

        public async Task DeleteArticleAsync(Guid articleId)
        {
            try
            {
                if (articleId == Guid.Empty) throw new ArgumentException("Article ID cannot be empty.");

                var article = await _unitOfWork.Articles.GetByIdAsync(articleId);
                if (article == null) throw new KeyNotFoundException("Article not found for deletion.");

                await _unitOfWork.Articles.DeleteAsync(article);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while deleting the article: " + ex.Message);
            }
        }

        public async Task<IEnumerable<ArticleDto>> GetMostReadArticlesAsync(int count)
        {
            try
            {
                if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than zero.");

                var articles = await _unitOfWork.Articles.GetMostReadArticlesAsync(count);
                return _mapper.Map<IEnumerable<ArticleDto>>(articles);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the most-read articles: " + ex.Message);
            }
        }
    }
}
