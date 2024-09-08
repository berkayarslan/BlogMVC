using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.ArticleDTOs;
using Application.DTOs.TopicDTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TopicService(IUnitOfWork unitOfWork, IMapper mapper, ITopicRepository topicRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _topicRepository = topicRepository ?? throw new ArgumentNullException(nameof(topicRepository));
        }

        public async Task<Guid> CreateTopicAsync(CreateTopicDto topicDto)
        {
            if (topicDto == null) throw new ArgumentNullException(nameof(topicDto), "Topic data cannot be null.");

            var topic = _mapper.Map<Topic>(topicDto);
            topic.Id = Guid.NewGuid();

            try
            {
                await _unitOfWork.Topics.AddAsync(topic);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while creating the topic: " + ex.Message, ex);
            }

            return topic.Id;
        }

        public async Task<IEnumerable<TopicDto>> GetAllTopicsAsync()
        {
            try
            {
                var topics = await _unitOfWork.Topics.GetAllAsync();
                return _mapper.Map<IEnumerable<TopicDto>>(topics);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving all topics: " + ex.Message, ex);
            }
        }

        public async Task DeleteTopicAsync(Guid topicId)
        {
            if (topicId == Guid.Empty) throw new ArgumentException("Topic ID cannot be empty.", nameof(topicId));

            var topic = await _unitOfWork.Topics.GetByIdAsync(topicId);
            if (topic == null) throw new KeyNotFoundException("Topic not found.");

            try
            {
                _unitOfWork.Topics.DeleteAsync(topic);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while deleting the topic: " + ex.Message, ex);
            }
        }

        public async Task<TopicDto> GetTopicByIdAsync(Guid topicId)
        {
            if (topicId == Guid.Empty) throw new ArgumentException("Topic ID cannot be empty.", nameof(topicId));

            try
            {
                var topic = await _unitOfWork.Topics.GetByIdAsync(topicId);
                if (topic == null) throw new KeyNotFoundException("Topic not found.");

                return _mapper.Map<TopicDto>(topic);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the topic by ID: " + ex.Message, ex);
            }
        }

        public async Task UpdateTopicAsync(TopicDto topicDto)
        {
            if (topicDto == null) throw new ArgumentNullException(nameof(topicDto), "Topic data cannot be null.");

            var topic = await _unitOfWork.Topics.GetByIdAsync(topicDto.Id);
            if (topic == null) throw new KeyNotFoundException("Topic not found for updating.");

            try
            {
                _mapper.Map(topicDto, topic);
                _unitOfWork.Topics.UpdateAsync(topic);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while updating the topic: " + ex.Message, ex);
            }
        }

        public async Task<IEnumerable<TopicDto>> GetTopicsWithArticlesAsync(Guid? topicId = null)
        {
            try
            {
                var topics = await _topicRepository.GetTopicsWithArticlesAsync(topicId);
                return _mapper.Map<IEnumerable<TopicDto>>(topics);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving topics with articles: " + ex.Message, ex);
            }
        }
    }
}