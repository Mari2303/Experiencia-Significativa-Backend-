namespace Entity.Dtos.ModuleOperation.CreateEvaluation
{
    public class EvaluationCriteriaInputDTO
    {

        public int CriteriaId { get; set; }  // id del criterio ya existente
        public List<int> Scores { get; set; } = new List<int>();       // valor otorgado por el evaluador
                                                                       // Nuevos campos que el user llena
                                                                       // campos de criteria 
        public string DescriptionContribution { get; set; } = string.Empty;
    
    }
}
