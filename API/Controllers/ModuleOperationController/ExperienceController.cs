using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class ExperienceController : BaseModelController<Experience, ExperienceDTO, ExperienceRequest>
    {
        private readonly IExperienceService _experienceService;
        private readonly IMapper _mapper;
        public ExperienceController(IBaseModelService<Experience, ExperienceDTO, ExperienceRequest> baseService, IExperienceService experienceService, IMapper mapper) : base(baseService, mapper)
        {
            _experienceService = experienceService;
            _mapper = mapper;
        }
    }
}
