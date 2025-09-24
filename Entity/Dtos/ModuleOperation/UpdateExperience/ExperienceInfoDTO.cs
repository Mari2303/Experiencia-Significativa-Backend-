using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.UpdateExperience
{
    public class ExperienceInfoDTO
    {

        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string NameExperiences { get; set; } = string.Empty;

        [Required]
        public DateTime Developmenttime { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string NameFirstLeader { get; set; } = string.Empty;

        [Required]
        public int StateId { get; set; }

         // Nuevo campo que refleja el estado según la evaluación
    public string State => EvaluationResult ?? "Naciente";

    // Esto requiere que pases el resultado de la evaluación al DTO
    public string EvaluationResult { get; set; }
    }
}
