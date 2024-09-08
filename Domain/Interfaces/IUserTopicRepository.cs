using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserTopicRepository
    {
        Task<IEnumerable<Guid>> GetFollowedTopicsByUserIdAsync(Guid userId);
        Task FollowTopicsAsync(Guid userId, IEnumerable<Guid> topicIds);
    }
}
