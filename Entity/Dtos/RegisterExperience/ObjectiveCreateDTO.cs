using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.RegisterExperience
{
    public class ObjectiveCreateDTO
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
    }
}
