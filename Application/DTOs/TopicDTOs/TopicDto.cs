using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.ArticleDTOs;
using Application.DTOs.ArticleTopicDTOs;

namespace Application.DTOs.TopicDTOs
{
    public class TopicDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ArticleDto> Articles { get; set; }
        public List<ArticleTopicDto> ArticleTopics { get; set; }
    }
}
