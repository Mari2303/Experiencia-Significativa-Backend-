using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Email;

namespace Service.Interfaces.IEmail
{
    public interface IPasswordRecoveryService
    {
        Task RequestRecoveryAsync(string email);
        Task<bool> VerifyCodeAsync(string email, string code);
        Task ResetPasswordAsync(PasswordResetDTO dto);
    }

}
