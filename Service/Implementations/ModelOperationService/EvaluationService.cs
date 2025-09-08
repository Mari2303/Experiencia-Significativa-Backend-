using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Interfaces.ModelOperationService;

namespace Service.Implementations.ModelOperationService
{
    public class EvaluationService : BaseModelService<Evaluation, EvaluationDTO, EvaluationRequest>, IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationService(IEvaluationRepository evaluationRepository) : base(evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

    }
}
