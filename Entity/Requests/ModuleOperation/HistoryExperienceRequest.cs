
using Entity.Models.ModelosParametros;
using Entity.Models.ModuleOperation;
using Entity.Models;

namespace Entity.Requests.ModuleOperation
{
    public class HistoryExperienceRequest : BaseRequest
    {
        public string Action { get; set; } = string.Empty;
        public string TableName { get; set; } = string.Empty;
        public int ExperienceId { get; set; }
        public string? Experience { get; set; } = null!;
        public int UserId { get; set; }
        public string? User { get; set; } = null!;
        public int StateId { get; set; }
        public string? State { get; set; } = null!;
    }
}
