using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.TopicDTOs;

namespace Application.Interfaces
{
    public interface IUserTopicService
    {
        Task FollowTopicsAsync(Guid userId, Guid[] topicIds);
        Task<IEnumerable<TopicDto>> GetFollowedTopicsAsync(Guid userId);
    }
}
