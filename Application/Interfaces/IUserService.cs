using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.ArticleDTOs;
using Application.DTOs.UserDTOs;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<Guid> CreateUserAsync(CreateUserDto userDto);
        Task<UpdateUserDto> GetUserByIdAsync(Guid userId);
        Task DeleteUserAsync(Guid userId);
        Task UpdateUserAsync(UpdateUserDto model);
        Task<UserDto> AuthenticateUserAsync(string email, string password);
        Task<IEnumerable<ArticleDto>> GetUserArticlesAsync(Guid userId);
    }
}
