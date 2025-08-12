using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Utilities.Mappers
{
    /// <summary>
    /// Defines a Permission mapper for mapping between entities and data transfer objects (DTOs).
    /// This class sets up mappings for the Permission model and its corresponding data transfer objects (DTOs).
    /// </summary>
    public class PermissionProfiles : Profile
    {
        public PermissionProfiles() : base()
        {
            /// <summary>
            /// Maps between <see cref="PermissionDTO"/> and <see cref="Permission"/> in both directions.
            /// </summary>
            CreateMap<PermissionDTO, Permission>().ReverseMap();

            /// <summary>
            /// Maps between <see cref="PermissionRequest"/> and <see cref="Permission"/> in both directions.
            /// </summary>
            CreateMap<PermissionRequest, Permission>().ReverseMap();
        }
    }
}