

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
        public DateTime Developmenttime { get; set; } = DateTime.Now;
        public string Recognition { get; set; } = string.Empty;
        public string Socialization { get; set; } = string.Empty;
        public string ThemeExperienceArea { get; set; } = string.Empty;
        public string CoordinationTransversalProjects { get; set; } = string.Empty;
        public string PedagogicalStrategies { get; set; } = string.Empty;
        public string Coverage { get; set; } = string.Empty;
        public string ExperiencesCovidPandemic { get; set; } = string.Empty;


        public int UserId { get; set; }
        public string? User { get; set; } = null!;
        public int InstitucionId { get; set; }
        public string? Institution { set; get; } = null!;
        public int StateId { get; set; }
        public string? State { get; set; } = null!;
    }
}
