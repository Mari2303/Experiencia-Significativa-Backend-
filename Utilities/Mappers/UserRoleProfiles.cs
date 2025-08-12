using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Utilities.Mappers
{
    /// <summary>
    /// Defines a UserRole mapper for mapping between entities and data transfer objects (DTOs).
    /// This class sets up mappings for the UserRole model and its corresponding data transfer objects (DTOs).
    /// </summary>
    public class UserRoleProfiles : Profile
    {
        public UserRoleProfiles() : base()
        {
            /// <summary>
            /// Maps between <see cref="UserRoleDTO"/> and <see cref="UserRole"/> in both directions.
            /// </summary>
            CreateMap<UserRoleDTO, UserRole>().ReverseMap();

            /// <summary>
            /// Maps between <see cref="UserRoleRequest"/> and <see cref="UserRole"/> in both directions.
            /// </summary>
            CreateMap<UserRoleRequest, UserRole>().ReverseMap();
        }
    }
}