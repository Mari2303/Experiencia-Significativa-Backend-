using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.ModuleOperation;
using Entity.Models;

namespace Entity.Requests.ModuleOperation
{
    public class EvaluationRequest : BaseRequest
    {
        public string TypeEvaluation { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string? User { get; set; } = null!;
        public int ExperienceId { get; set; }
        public string? Experience { get; set; } = null!;
    }
}
