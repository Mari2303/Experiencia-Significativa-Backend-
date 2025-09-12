

using Entity.Models.ModuleOperation;

namespace Entity.Models.ModelosParametros
{
    public class Grade : GenericModel
    {
     

        public virtual ICollection<ExperienceGrade> ExperienceGrades { get; set; } = new List<ExperienceGrade>();
    }
}
