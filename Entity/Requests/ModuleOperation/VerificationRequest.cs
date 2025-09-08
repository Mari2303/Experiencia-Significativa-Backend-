using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.ModuleOperation;

namespace Entity.Requests.ModuleOperation
{
    public class VerificationRequest : BaseRequest
    {


        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ExperienceId { get; set; }
        public string? Experience { get; set; } = null!;
    }
}
