using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Utilities.Mappers
{
    /// <summary>
    /// Defines a Form mapper for mapping between entities and data transfer objects (DTOs).
    /// This class sets up mappings for the Form model and its corresponding data transfer objects (DTOs).
    /// </summary>
    public class FormProfiles : Profile
    {
        public FormProfiles() : base()
        {

            /// <summary>
            /// Maps between <see cref="FormDTO"/> and <see cref="Form"/> in both directions.
            /// </summary>
            CreateMap<FormDTO, Form>().ReverseMap();

            /// <summary>
            /// Maps between <see cref="FormRequest"/> and <see cref="Form"/> in both directions.
            /// </summary>
            CreateMap<FormRequest, Form>().ReverseMap();
        }
    }
}