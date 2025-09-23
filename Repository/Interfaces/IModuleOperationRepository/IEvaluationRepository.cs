using Entity.Dtos.ModuleOperation.CreateEvaluation;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModelosParametros;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Repository.Interfaces.IModuleOperationRepository
{
    public interface IEvaluationRepository : IBaseModelRepository<Evaluation, EvaluationDTO, EvaluationRequest>
    {
        Task<Evaluation> AddEvaluationAsync(Evaluation evaluation);
        Task AddEvaluationCriteriaAsync(EvaluationCriteria evalCriteria);
        Task<Experience?> GetExperienceWithInstitutionAsync(int experienceId);
        Task UpdateCriteriaAsync(Criteria criteria);
        Task SaveChangesAsync();
        Task<Criteria?> GetCriteriaByIdAsync(int id);
        Task<EvaluationDetailDTO> GetEvaluationDetailAsync(int id);
    }
}
