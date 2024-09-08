using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.TopicDTOs;

namespace Application.Interfaces
{
    public interface ITopicService
    {
        Task<IEnumerable<TopicDto>> GetAllTopicsAsync();
        Task<Guid> CreateTopicAsync(CreateTopicDto topicDto);
        Task DeleteTopicAsync(Guid topicId);
        Task UpdateTopicAsync(TopicDto topicDto);
        Task<TopicDto> GetTopicByIdAsync(Guid topicId);
        Task<IEnumerable<TopicDto>> GetTopicsWithArticlesAsync(Guid? topicId = null);
    }
}
