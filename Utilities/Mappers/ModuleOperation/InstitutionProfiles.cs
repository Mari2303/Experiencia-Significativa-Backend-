using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Utilities.Mappers.ModuleOperation
{
    public class InstitutionProfiles : Profile

    {
        public InstitutionProfiles() : base()
        {
            CreateMap<InstitutionDTO, Institution>().ReverseMap();
            CreateMap<InstitutionRequest,Institution>().ReverseMap();
        }
    }
}
