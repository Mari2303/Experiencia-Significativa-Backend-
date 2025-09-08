
using Entity.Models.ModuleOperation;

namespace Entity.Models.ModelosParametros
{
    public class LineThematic : BaseModel
    {
        public string Name { get; set; }= string.Empty;
        public string Code { get; set; } = string.Empty;

        public virtual ICollection<ExperienceLineThematic> ExperienceLineThematics { get; set; } = new List<ExperienceLineThematic>();

    }
}
