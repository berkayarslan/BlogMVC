using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.ArticleDTOs;
using Application.DTOs.UserDTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<Guid> CreateUserAsync(CreateUserDto model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model), "User data cannot be null.");

            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return user.Id;
            }

            var errors = result.Errors.Select(e => e.Description);
            throw new ApplicationException("User creation failed: " + string.Join(", ", errors));
        }

        public async Task<UpdateUserDto> GetUserByIdAsync(Guid userId)
        {
            if (userId == Guid.Empty) throw new ArgumentException("User ID cannot be empty.", nameof(userId));

            var user = await _unitOfWork.Users.GetByIdWithIncludesAsync(userId);
            if (user == null) throw new KeyNotFoundException("User not found.");

            var updateUserDto = _mapper.Map<UpdateUserDto>(user);

            if (!string.IsNullOrEmpty(user.ProfileImageUrl))
            {
                updateUserDto.ExistingProfileImageUrl = user.ProfileImageUrl;
            }

            return updateUserDto;
        }


        public async Task DeleteUserAsync(Guid userId)
        {
            if (userId == Guid.Empty) throw new ArgumentException("User ID cannot be empty.", nameof(userId));

            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null) throw new KeyNotFoundException("User not found.");

            try
            {
                _unitOfWork.Users.DeleteAsync(user);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while deleting the user: " + ex.Message, ex);
            }
        }

        public async Task UpdateUserAsync(UpdateUserDto model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model), "User data cannot be null.");

            var user = await _userManager.FindByIdAsync(model.Id.ToString());
            if (user == null) throw new KeyNotFoundException("User not found.");

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Bio = model.Bio;
            user.Email = model.Email;
            user.UserName = model.Email;

            if (!string.IsNullOrWhiteSpace(model.ExistingProfileImageUrl))
            {
                user.ProfileImageUrl = model.ExistingProfileImageUrl;
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new ApplicationException("User update failed: " + string.Join(", ", errors));
            }

            await _unitOfWork.SaveAsync();
        }

        public async Task<UserDto> AuthenticateUserAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email cannot be empty.", nameof(email));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be empty.", nameof(password));

            var user = await _unitOfWork.Users.GetByEmailAsync(email);
            if (user == null) throw new KeyNotFoundException("User not found.");

            var result = await _userManager.CheckPasswordAsync(user, password);
            if (!result)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<ArticleDto>> GetUserArticlesAsync(Guid userId)
        {
            if (userId == Guid.Empty) throw new ArgumentException("User ID cannot be empty.", nameof(userId));

            var articles = await _unitOfWork.Articles.GetArticlesByAuthorIdAsync(userId);
            if (articles == null || !articles.Any()) throw new KeyNotFoundException("No articles found for the user.");

            return articles.Select(article => new ArticleDto
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                CreatedAt = article.CreatedAt,
                AuthorId = article.AuthorId
            });
        }
    }
}
