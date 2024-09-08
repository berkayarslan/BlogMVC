using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ArticleTopic
    {
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }

        public Guid TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
