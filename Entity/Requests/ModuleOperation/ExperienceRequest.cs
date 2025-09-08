

namespace Entity.Requests.ModuleOperation
{
    public class ExperienceRequest : BaseRequest
    {
        public string NameExperiences { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Methodologias { get; set; } = string.Empty;
        public string Tranfer { get; set; } = string.Empty;
        public string? Verification { get; set; } = null;
        public string Code { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string? User { get; set; } = null!;
        public int InstitucionId { get; set; }
        public string? Institution { set; get; } = null!;
    }
}
