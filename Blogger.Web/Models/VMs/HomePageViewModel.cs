using Application.DTOs.ArticleDTOs;
using Application.DTOs.TopicDTOs;

namespace Blogger.Web.Models.VMs
{
    public class HomePageViewModel
    {
        public IEnumerable<ArticleDto> MostReadArticles { get; set; }
        public IEnumerable<TopicDto> Topics { get; set; }
    }
}
