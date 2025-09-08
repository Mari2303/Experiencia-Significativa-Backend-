using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.ModuleOperation
{
    public class InstitutionRequest : BaseRequest
    {
        public string Address { get; set; } = string.Empty;
        public int Phone { get; set; }
        public string EmailInstitucional { get; set; } = string.Empty;
        public string Departament { get; set; } = string.Empty;
        public string Commune { get; set; } = string.Empty;
    }
}
