

namespace Entity.Models.ModuleOperation
{
    public class Objective : BaseModel
    {
        public string DescriptionProblem { get; set; } = string.Empty;
        public string ObjectiveExperience { get; set; } = string.Empty;
        public string EnfoqueExperience { get; set; } = string.Empty;
        public string Methodologias { get; set; } = string.Empty;
        public string InnovationExperience { get; set; } = string.Empty;
        public string ResulsExperience { get; set; } = string.Empty;
        public string SustainabilityExperience { get; set; } = string.Empty;
        public string Tranfer { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string MetaphoricalPhrase { get; set; } = string.Empty;
        public string Testimony { get; set; } = string.Empty;
        public string FollowEvaluation { get; set; } = string.Empty;
        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; } = null!;

    }
}
