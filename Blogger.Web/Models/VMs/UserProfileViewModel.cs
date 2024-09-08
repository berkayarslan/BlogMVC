using Application.DTOs.ArticleDTOs;
using Application.DTOs.TopicDTOs;
using Application.DTOs.UserDTOs;

namespace Blogger.Web.Models.VMs
{
    public class UserProfileViewModel
    {
        public UpdateUserDto User { get; set; }
        public IEnumerable<ArticleDto> Articles { get; set; }
        public IEnumerable<TopicDto> FollowedTopics { get; set; }
        public IEnumerable<TopicDto> AvailableTopics { get; set; }
        public List<TopicDto> Topics { get; set; } // Takip edilen konular
        public List<TopicDto> AllTopics { get; set; } // Tüm konular, seçim için
    }
}
