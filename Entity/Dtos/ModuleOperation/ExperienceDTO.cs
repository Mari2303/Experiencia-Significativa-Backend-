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
        public int UserId { get; set; }
        public int InstitucionId { get; set; }
    }
}
