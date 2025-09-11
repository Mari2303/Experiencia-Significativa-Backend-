
using Entity.Models.ModuleOperation;

namespace Entity.Models.ModelosParametros
{
    public class Criteria : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public ICollection<EvaluationCriteria> EvaluationCriterias { get; set; } = new List<EvaluationCriteria>();
    }
}
