

namespace Entity.Models.ModuleOperation
{
    public class Verification : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; } = null!;
    }
}
