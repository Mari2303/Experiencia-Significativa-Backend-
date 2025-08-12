using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Utilities.Mappers
{
    /// <summary>
    /// Defines a RoleFormPermission mapper for mapping between entities and data transfer objects (DTOs).
    /// This class sets up mappings for the RoleFormPermission model and its corresponding data transfer objects (DTOs).
    /// </summary>
    public class RoleFormPermissionProfiles : Profile
    {
        public RoleFormPermissionProfiles() : base()
        {
            /// <summary>
            /// Maps between <see cref="RoleFormPermissionDTO"/> and <see cref="RoleFormPermission"/> in both directions.
            /// </summary>
            CreateMap<RoleFormPermissionDTO, RoleFormPermission>().ReverseMap();

            /// <summary>
            /// Maps between <see cref="RoleFormPermissionRequest"/> and <see cref="RoleFormPermission"/> in both directions.
            /// </summary>
            CreateMap<RoleFormPermissionRequest, RoleFormPermission>().ReverseMap();
        }
    }
}