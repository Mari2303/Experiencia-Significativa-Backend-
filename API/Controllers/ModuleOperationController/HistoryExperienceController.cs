using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class HistoryExperienceController : BaseModelController<HistoryExperience, HistoryExperienceDTO, HistoryExperienceRequest>
    {
        private readonly IHistoryExperienceService _historyExperienceService;
        private readonly IMapper _mapper;
        public HistoryExperienceController(IBaseModelService<HistoryExperience, HistoryExperienceDTO, HistoryExperienceRequest> baseService, IHistoryExperienceService historyExperienceService, IMapper mapper) : base(baseService, mapper)
        {
            _historyExperienceService = historyExperienceService;
            _mapper = mapper;
        }
    }
}
