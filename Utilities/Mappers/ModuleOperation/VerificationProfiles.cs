using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Utilities.Mappers.ModuleOperation
{
    public class VerificationProfiles : Profile
    {
        public VerificationProfiles() : base()
        {
            CreateMap<VerificationDTO, Verification>().ReverseMap();
            CreateMap<VerificationRequest, Verification>().ReverseMap();
        }
    }
}
