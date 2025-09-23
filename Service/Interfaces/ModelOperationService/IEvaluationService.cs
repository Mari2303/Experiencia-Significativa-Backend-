using Entity.Dtos.ModuleOperation.CreateEvaluation;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Service.Interfaces.ModelOperationService
{
    public interface IEvaluationService : IBaseModelService<Evaluation, EvaluationDTO, EvaluationRequest>
    {
        Task<EvaluationDetailDTO> CreateEvaluationAsync(EvaluationRegisterDTO dto);
    }
}
