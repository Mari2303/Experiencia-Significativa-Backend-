

namespace Entity.Dtos.CreateEvaluation
{
    public class EvaluationCriteriaInputDTO
    {

        public int CriteriaId { get; set; }  // id del criterio ya existente
        public int Score { get; set; }       // valor otorgado por el evaluador
                                             // 🔹 Nuevos campos que el user llena
        // campos de criteria 
        public string DescriptionContribution { get; set; } = string.Empty;
        public string DescruotionType { get; set; } = string.Empty;
    }
}
