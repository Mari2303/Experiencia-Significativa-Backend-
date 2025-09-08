

namespace Entity.Requests.ModuleOperation
{
    public class ObjectiveRequest : BaseRequest
    {
        public string DescriptionProblem { get; set; } = string.Empty;
        public string ObjectiveExperience { get; set; } = string.Empty;
        public string EnfoqueExperience { get; set; } = string.Empty;
        public string InnovationExperience { get; set; } = string.Empty;
        public string ResulsExperience { get; set; } = string.Empty;
        public string SustainabilityExperience { get; set; } = string.Empty;
        public string MetaphoricalPhrase { get; set; } = string.Empty;
        public string Testimony { get; set; } = string.Empty;
        public string Dissemination { get; set; } = string.Empty;
        public int ExperienceId { get; set; }
        public string? Experience { get; set; } = null!;
    }
}
