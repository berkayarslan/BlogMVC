using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserTopic
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
