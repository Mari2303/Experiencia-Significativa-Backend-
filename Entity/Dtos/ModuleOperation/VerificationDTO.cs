

namespace Entity.Dtos.ModuleOperational
{
    public class VerificationDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ExperienceId { get; set; }
    }
}
