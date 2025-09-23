using Entity.Dtos.ModelosParametro;

namespace Entity.Dtos.ModuleOperation.CreateEvaluation
{
    public  class EvaluationRegisterDTO
    {
        // --- Campos propios de Evaluation ---
        public string TypeEvaluation { get; set; } = string.Empty;
        public string AccompanimentRole { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string EvaluationResult { get; set; } = string.Empty;

        public int UserId { get; set; }
        public int ExperienceId { get; set; }

        // --- Criterios a evaluar ---
        public List<EvaluationCriteriaInputDTO> CriteriaEvaluations { get; set; } = new();
     





    }
}
