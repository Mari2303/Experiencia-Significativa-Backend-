using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Utilities.Mappers
{
    /// <summary>
    /// Defines a Role mapper for mapping between entities and data transfer objects (DTOs).
    /// This class sets up mappings for the Role model and its corresponding data transfer objects (DTOs).
    /// </summary>
    public class RoleProfiles : Profile
    {
        public RoleProfiles() : base()
        {
            /// <summary>
            /// Maps between <see cref="RoleDTO"/> and <see cref="Role"/> in both directions.
            /// </summary>
            CreateMap<RoleDTO, Role>().ReverseMap();

            /// <summary>
            /// Maps between <see cref="RoleRequest"/> and <see cref="Role"/> in both directions.
            /// </summary>
            CreateMap<RoleRequest, Role>().ReverseMap();
        }
    }
}