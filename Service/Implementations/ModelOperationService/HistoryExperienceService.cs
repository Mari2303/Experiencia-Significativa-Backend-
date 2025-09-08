using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Interfaces.ModelOperationService;


namespace Service.Implementations.ModelOperationService
{
    public class HistoryExperienceService : BaseModelService<HistoryExperience, HistoryExperienceDTO, HistoryExperienceRequest>, IHistoryExperienceService
    {
        private readonly IHistoryExperienceRepository _historyExperienceRepository;
        public HistoryExperienceService(IHistoryExperienceRepository historyExperienceRepository) : base(historyExperienceRepository)
        {
            _historyExperienceRepository = historyExperienceRepository;
        }
    }
}
