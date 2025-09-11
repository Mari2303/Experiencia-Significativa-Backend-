using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Utilities.Mappers.ModuleOperation
{
    public class EvaluationProfiles : Profile
    {
        public EvaluationProfiles() : base()
        {
            CreateMap<EvaluationDTO, Evaluation>().ReverseMap();
            CreateMap<EvaluationRequest, Evaluation>().ReverseMap();
        }
    }
}
