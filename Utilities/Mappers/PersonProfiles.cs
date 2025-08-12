using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Utilities.Mappers
{
    /// <summary>
    /// Defines a Person mapper for mapping between entities and data transfer objects (DTOs).
    /// This class sets up mappings for the Person model and its corresponding data transfer objects (DTOs).
    /// </summary>
    public class PersonProfiles : Profile
    {
        public PersonProfiles() : base()
        {
            /// <summary>
            /// Maps between <see cref="PersonDTO"/> and <see cref="Person"/> in both directions.
            /// </summary>
            CreateMap<PersonDTO, Person>().ReverseMap();

            /// <summary>
            /// Maps between <see cref="PersonRequest"/> and <see cref="Person"/> in both directions.
            /// </summary>
            CreateMap<PersonRequest, Person>().ReverseMap();
        }
    }
}