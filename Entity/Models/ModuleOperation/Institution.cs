using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.ModuleOperation
{
    public class Institution : GenericModel
    {
        public string Address { get; set; } = string.Empty;
        public int Phone { get; set; }
        public string EmailInstitucional { get; set; } = string.Empty;
        public string Departament { get; set; } = string.Empty;
        public string Commune { get; set; } = string.Empty;
        public ICollection<Experience> Experiences { get; set; } = new List<Experience>();
    }
}
