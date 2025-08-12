using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Utilities.Mappers
{
    /// <summary>
    /// Defines a Module mapper for mapping between entities and data transfer objects (DTOs).
    /// This class sets up mappings for the Module model and its corresponding data transfer objects (DTOs).
    /// </summary>
    public class ModuleProfiles : Profile
    {

        public ModuleProfiles() : base()
        {

            /// <summary>
            /// Maps between <see cref="ModuleDTO"/> and <see cref="Module"/> in both directions.
            /// </summary>
            CreateMap<ModuleDTO, Module>().ReverseMap();

            /// <summary>
            /// Maps between <see cref="ModuleRequest"/> and <see cref="Module"/> in both directions.
            /// </summary>
            CreateMap<ModuleRequest, Module>().ReverseMap();
        }
    }
}