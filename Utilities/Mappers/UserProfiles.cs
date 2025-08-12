using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Utilities.JwtAuthentication;

namespace Utilities.Mappers
{
    /// <summary>
    /// Defines a User mapper for mapping between entities and data transfer objects (DTOs).
    /// This class sets up mappings for the User model and its corresponding data transfer objects (DTOs).
    /// </summary>
    public class UserProfiles : Profile
    {
        private readonly IJwtAuthentication _jwtAuthentication;

        public UserProfiles(IJwtAuthentication jwtAuthentication) : base()
        {
            _jwtAuthentication = jwtAuthentication;

            // Mapping from UserRequest to User with password encryption and CreatedAt set to the current UTC time minus 5 hours
            CreateMap<UserDTO, User>()
              .ForMember(dest => dest.Password, opt => opt.MapFrom(src => _jwtAuthentication.EncryptMD5(src.Password)));

            CreateMap<User, UserDTO>();

            // Mapping from UserRequest to User with password encryption and CreatedAt set to the current UTC time minus 5 hours
            CreateMap<UserRequest, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => _jwtAuthentication.EncryptMD5(src.Password)));

            CreateMap<User, UserRequest>();
        }
    }
}