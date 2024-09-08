using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.UserDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // CreateUserDto -> User mapping
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // Password hashing should be handled in the service layer

            // UpdateUserDto -> User mapping
            CreateMap<UpdateUserDto, User>()
                .ForMember(dest => dest.ProfileImageUrl, opt => opt.MapFrom(src => src.ExistingProfileImageUrl));

            CreateMap<User, UpdateUserDto>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            // Ters yönlü map
            CreateMap<UpdateUserDto, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            // User -> UserDto mapping
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>();

            // User -> UpdateUserDto mapping
            CreateMap<User, UpdateUserDto>();

            CreateMap<UpdateUserDto, UserDto>();
        }
    }
}
