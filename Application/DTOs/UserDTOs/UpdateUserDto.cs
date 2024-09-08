using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.ArticleDTOs;
using Application.DTOs.TopicDTOs;
using Microsoft.AspNetCore.Http;

namespace Application.DTOs.UserDTOs
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string? LastName { get; set; }
        public string? Bio { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public string? ExistingProfileImageUrl { get; set; }
        public string? ProfileImageUrl { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }
        public IEnumerable<ArticleDto>? Articles { get; set; }

        public List<TopicDto> Topics { get; set; }

        public List<TopicDto> FollowedTopics { get; set; }

    }
}
