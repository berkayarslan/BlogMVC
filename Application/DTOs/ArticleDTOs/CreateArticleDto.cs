using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DTOs.ArticleDTOs
{
    public class CreateArticleDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        public string? Content { get; set; }

        public Guid? AuthorId { get; set; } // Nullable Guid

        [Required(ErrorMessage = "At least one topic must be provided.")]
        public string? Topics { get; set; }

        public IFormFile? Image { get; set; }
    }
}
