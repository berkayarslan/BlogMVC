using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<ArticleTopic> ArticleTopics { get; set; } = new List<ArticleTopic>();
        public int ReadCount { get; set; }
    }

}
