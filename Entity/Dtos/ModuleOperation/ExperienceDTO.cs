using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.ModuleOperation;

namespace Entity.Dtos.ModuleOperational
{
    public class ExperienceDTO : BaseDTO
    {
        public string NameExperiences { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Methodologias { get; set; } = string.Empty;
        public string Tranfer { get; set; } = string.Empty;
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
        public int StateId { get; set; }
        public int InstitucionId { get; set; }
    }
}


