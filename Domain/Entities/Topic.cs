using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Topic
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<ArticleTopic> ArticleTopics { get; set; } = new List<ArticleTopic>();

        public ICollection<UserTopic> UserTopics { get; set; }
    }
}
