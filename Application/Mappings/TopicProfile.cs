using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.TopicDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class TopicProfile : Profile
    {
        public TopicProfile()
        {
            CreateMap<CreateTopicDto, Topic>();

            CreateMap<Topic, TopicDto>();

            CreateMap<Topic, TopicDto>()
            .ForMember(dest => dest.Articles, opt => opt.MapFrom(src => src.ArticleTopics.Select(at => at.Article)));
        }
    }
}
