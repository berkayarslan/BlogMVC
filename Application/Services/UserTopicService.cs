using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.TopicDTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class UserTopicService : IUserTopicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserTopicService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task FollowTopicsAsync(Guid userId, Guid[] topicIds)
        {
            if (userId == Guid.Empty) throw new ArgumentException("User ID cannot be empty.", nameof(userId));
            if (topicIds == null || topicIds.Length == 0) throw new ArgumentException("Topic IDs cannot be null or empty.", nameof(topicIds));

            var user = await _unitOfWork.Users.GetByIdWithIncludesAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            var existingTopicIds = user.UserTopics.Select(ut => ut.TopicId).ToList();
            var newTopicIds = topicIds.Except(existingTopicIds).ToList();

            if (newTopicIds.Any())
            {
                foreach (var topicId in newTopicIds)
                {
                    user.UserTopics.Add(new UserTopic { UserId = userId, TopicId = topicId });
                }

                try
                {
                    await _unitOfWork.SaveAsync();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("An error occurred while following the topics: " + ex.Message, ex);
                }
            }
        }

        public async Task<IEnumerable<TopicDto>> GetFollowedTopicsAsync(Guid userId)
        {
            if (userId == Guid.Empty) throw new ArgumentException("User ID cannot be empty.", nameof(userId));

            var user = await _unitOfWork.Users.GetByIdWithIncludesAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            var topics = user.UserTopics.Select(ut => ut.Topic).ToList();

            return _mapper.Map<IEnumerable<TopicDto>>(topics);
        }
    }
}
