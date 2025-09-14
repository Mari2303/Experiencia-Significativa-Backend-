using Entity.Dtos.CreateEvaluation;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModelosParametros;
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



        public async Task<EvaluationDetailDTO> CreateEvaluationAsync(EvaluationRegisterDTO dto)
        {
            var experience = await _evaluationRepository.GetExperienceWithInstitutionAsync(dto.ExperienceId)
             ?? throw new KeyNotFoundException("La experiencia no existe");

            // Crear evaluación
            var evaluation = new Evaluation
            {
                TypeEvaluation = dto.TypeEvaluation,
                AccompanimentRole = dto.AccompanimentRole,
                Comments = dto.Comments,
                UserId = dto.UserId,
                ExperienceId = dto.ExperienceId,
                State = true,
                CreatedAt = DateTime.UtcNow

            };

            evaluation = await _evaluationRepository.AddEvaluationAsync(evaluation);

            int totalScore = 0;

            foreach (var c in dto.CriteriaEvaluations)
            {
                // 🔹 Guardamos Score en la pivote
                var evalCriteria = new EvaluationCriteria
                {
                    EvaluationId = evaluation.Id,
                    CriteriaId = c.CriteriaId,
                    Score = c.Score,
                    State = true,
                    CreatedAt = DateTime.UtcNow
                };
                await _evaluationRepository.AddEvaluationCriteriaAsync(evalCriteria);

                // 🔹 Actualizamos campos de Criteria
                var criteria = await _evaluationRepository.GetCriteriaByIdAsync(c.CriteriaId);
                if (criteria != null)
                {
                    criteria.DescriptionContribution = c.DescriptionContribution;
                    criteria.DescruotionType = c.DescruotionType;
                    await _evaluationRepository.UpdateCriteriaAsync(criteria);
                }

                totalScore += c.Score;
            }

           

            evaluation.EvaluationResult = CalcularResultadoFinal(totalScore);
            await _evaluationRepository.SaveChangesAsync();

            return new EvaluationDetailDTO
            {
                EvaluationId = evaluation.Id,
                TypeEvaluation = evaluation.TypeEvaluation,
                AccompanimentRole = evaluation.AccompanimentRole,
                Comments = evaluation.Comments,
                EvaluationResult = evaluation.EvaluationResult,
                ExperienceId = experience.Id,
                ExperienceName = experience.NameExperiences,
                StateId = experience.StateId,
                InstitutionName = experience.Institution?.Name ?? string.Empty,
                CriteriaEvaluations = dto.CriteriaEvaluations
                    .Select(c => new EvaluationCriteriaDTO
                    {
                        CriteriaId = c.CriteriaId,
                        Score = c.Score,
                        EvaluationId = evaluation.Id
                    }).ToList()
            };
        }

        private string CalcularResultadoFinal(int totalScore) =>
    totalScore <= 45 ? "Naciente" :
    totalScore <= 79 ? "Creciente" : "Inspiradora";
    }
}

