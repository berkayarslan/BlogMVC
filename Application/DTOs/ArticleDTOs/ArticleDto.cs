using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.ArticleTopicDTOs;
using Microsoft.AspNetCore.Http;

namespace Application.DTOs.ArticleDTOs
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public List<string?> Topics { get; set; }
        public List<Guid> TopicIds { get; set; }
        public string? ImageUrl { get; set; }
        public List<ArticleTopicDto>? ArticleTopics { get; set; }
    }
}
