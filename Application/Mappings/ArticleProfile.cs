using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.ArticleDTOs;
using Application.DTOs.ArticleTopicDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<CreateArticleDto, Article>()
                .ForMember(dest => dest.ArticleTopics, opt => opt.Ignore()) 
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()); 

            CreateMap<Article, ArticleDto>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"))
                .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.ArticleTopics.Select(at => at.Topic.Name).ToList()))
                .ForMember(dest => dest.ArticleTopics, opt => opt.MapFrom(src => src.ArticleTopics));

            CreateMap<ArticleTopic, ArticleTopicDto>()
            .ForMember(dest => dest.Article, opt => opt.MapFrom(src => src.Article))
            .ForMember(dest => dest.Topic, opt => opt.MapFrom(src => src.Topic));

            CreateMap<ArticleDto, Article>();


           CreateMap<UpdateArticleDto, Article>()
            .ForMember(dest => dest.ArticleTopics, opt => opt.Ignore()) // TopicId listesi manuel olarak işlenir
            .AfterMap((src, dest) =>
            {
                if (src.TopicIds != null)
                {
                    dest.ArticleTopics = src.TopicIds
                        .Where(tid => tid.HasValue)
                        .Select(tid => new ArticleTopic { TopicId = tid.Value, ArticleId = dest.Id })
                        .ToList();
                }
            });
        }
    }
}
