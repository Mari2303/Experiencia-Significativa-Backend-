using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.RegisterExperience
{
    public class InstitutionCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public uint Phone { get; set; }
        public string CodeDane { get; set; } = string.Empty;
        public string EmailInstitucional { get; set; } = string.Empty;
        public string Departament { get; set; } = string.Empty;
        public string Commune { get; set; } = string.Empty;
        public string Municipality { get; set; } = string.Empty;
        public string NameRector { get; set; } = string.Empty;
        public string EZone { get; set; } = string.Empty;
        public string Caracteristic { get; set; } = string.Empty;
        public string TerritorialEntity { get; set; } = string.Empty;
        public string TestsKnow { get; set; } = string.Empty;
    }
}
