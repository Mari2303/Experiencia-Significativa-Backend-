

using Entity.Models.ModuleOperation;

namespace Entity.Models.ModelosParametros
{
    public class Grade : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public ICollection<ExperienceGrade> ExperienceGrades { get; set; } = new List<ExperienceGrade>();
    }
}
