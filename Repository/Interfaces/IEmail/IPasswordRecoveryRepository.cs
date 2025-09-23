using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.ModuleOperation;

namespace Repository.Interfaces.IEmail
{
    public interface IPasswordRecoveryRepository
    {
        Task AddAsync(PasswordRecovery recovery);
        Task<PasswordRecovery?> GetActiveRecoveryAsync(string email, string code);
        Task DeactivateAsync(PasswordRecovery recovery);
    }
}
