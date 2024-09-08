using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.ArticleDTOs;
using Application.DTOs.TopicDTOs;

namespace Application.DTOs.ArticleTopicDTOs
{
    public class ArticleTopicDto
    {
        public Guid ArticleId { get; set; }
        public ArticleDto Article { get; set; }

        public Guid TopicId { get; set; }
        public TopicDto Topic { get; set; }
    }
}
