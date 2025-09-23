using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.ModuleOperation
{
    public class PasswordRecovery : BaseModel
    {
        
        public string Email { get; set; } = null!;
        public string Code { get; set; } = null!;
        public DateTime Expiration { get; set; }

    }
}
