using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Utilities.Mappers
{
    /// <summary>
    /// Defines a FormModule mapper for mapping between entities and data transfer objects (DTOs).
    /// This class sets up mappings for the FormModule model and its corresponding data transfer objects (DTOs).
    /// </summary>
    public class FormModuleProfiles : Profile
    {
        public FormModuleProfiles() : base()
        {
            /// <summary>
            /// Maps between <see cref="FormModuleDTO"/> and <see cref="FormModule"/> in both directions.
            /// </summary>
            CreateMap<FormModuleDTO, FormModule>().ReverseMap();

            /// <summary>
            /// Maps between <see cref="FormModuleRequest"/> and <see cref="FormModule"/> in both directions.
            /// </summary>
            CreateMap<FormModuleRequest, FormModule>().ReverseMap();
        }
    }
}