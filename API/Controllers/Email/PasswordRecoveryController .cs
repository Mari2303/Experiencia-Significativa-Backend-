using Entity.Dtos.Email;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.IEmail;

namespace API.Controllers.Email
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordRecoveryController : ControllerBase
    {
        private readonly IPasswordRecoveryService _service;

        public PasswordRecoveryController(IPasswordRecoveryService service)
        {
            _service = service;
        }

        [HttpPost("request")]
        public async Task<IActionResult> RequestRecovery([FromBody] PasswordRecoveryRequesDTO dto)
        {
            try
            {
                await _service.RequestRecoveryAsync(dto.Email);
                return Ok(new { message = "Código enviado al correo si existe la cuenta." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyCode([FromBody] PasswordRecoveryVerifyDTO dto)
        {
            var valid = await _service.VerifyCodeAsync(dto.Email, dto.Code);
            if (!valid) return BadRequest(new { message = "Código inválido o expirado." });
            return Ok(new { message = "Código válido." });
        }

        [HttpPost("reset")]
        public async Task<IActionResult> ResetPassword([FromBody] PasswordResetDTO dto)
        {
            try
            {
                await _service.ResetPasswordAsync(dto);
                return Ok(new { message = "Contraseña actualizada correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

