using Entity.Dtos.Email;
using Entity.Models.ModuleOperation;
using Repository.Interfaces.IEmail;
using Repository.Interfaces;
using Service.Interfaces;
using Utilities.JwtAuthentication;
using Utilities.Messaging.Interfaces;

namespace Service.Implementations.Email;
public class PasswordRecoveryService : IPasswordRecoveryService
{
    private readonly IUserRepository _userRepo;
    private readonly IPasswordRecoveryRepository _recoveryRepo;
    private readonly IEmailService _emailService;
    private readonly IJwtAuthentication _jwtAuthentication; 

    public PasswordRecoveryService(
        IUserRepository userRepo,
        IPasswordRecoveryRepository recoveryRepo,
        IEmailService emailService,
        IJwtAuthentication jwtAuthentication)
    {
        _userRepo = userRepo;
        _recoveryRepo = recoveryRepo;
        _emailService = emailService;
        _jwtAuthentication = jwtAuthentication;
    }

    public async Task RequestRecoveryAsync(string email)
    {
        var user = await _userRepo.GetByEmailAsync(email);
        if (user == null)
            throw new Exception("El correo no está registrado.");

        // Generar código seguro (6 dígitos)
        var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
        var bytes = new byte[4];
        rng.GetBytes(bytes);
        int value = Math.Abs(BitConverter.ToInt32(bytes, 0)) % 900000 + 100000;
        var code = value.ToString();

        var recovery = new PasswordRecovery
        {
            Email = email,
            Code = code,
            Expiration = DateTime.UtcNow.AddMinutes(10),
            Active = true
        };

        await _recoveryRepo.AddAsync(recovery);

        // Enviar correo (tu EmailService)
        await _emailService.SendExperiencesEmail(email, code);
    }

    public async Task<bool> VerifyCodeAsync(string email, string code)
    {
        var recovery = await _recoveryRepo.GetActiveRecoveryAsync(email, code);
        if (recovery == null) return false;
        if (recovery.Expiration < DateTime.UtcNow) return false;
        return true;
    }

    public async Task ResetPasswordAsync(PasswordResetDTO dto)
    {
        var recovery = await _recoveryRepo.GetActiveRecoveryAsync(dto.Email, dto.Code);
        if (recovery == null || recovery.Expiration < DateTime.UtcNow)
            throw new Exception("El código es inválido o expiró.");

        var user = await _userRepo.GetByEmailAsync(dto.Email);
        if (user == null)
            throw new Exception("Usuario no encontrado.");

        // Cifrar la contraseña con el mismo método de tu app (usaste EncryptMD5 en otros lugares)
        user.Password = _jwtAuthentication.EncryptMD5(dto.NewPassword);

        // Actualizar usuario (UpdateAsync hace SaveChanges interno)
        await _userRepo.UpdateAsync(user);

        // Desactivar código
        await _recoveryRepo.DeactivateAsync(recovery);
    }
}
