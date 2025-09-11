using AutoMapper;
using Entity.Models;
using Entity.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        /// <summary>
        /// Authentication method
        /// </summary>
        /// <param name="auten"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync([FromBody] AuthenticationRequest auth)
        {
            try
                {
                UserLoginResponseRequest data = await _authService.LoginAsync(auth.Username, auth.Password);
                return Ok(new ApiResponseRequest<UserLoginResponseRequest>(data, true, "Session started successfully"));
            }
            catch (Exception ex)
            {
                var response = new ApiResponseRequest<UserLoginResponseRequest>(null!, false, ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Method to update key
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("UpdatePassword")]
        public async Task<ActionResult> UpdatePassword([FromBody] ChangePasswordRequest dto)
        {
            try
            {
                await _authService.ChangePasswordAsync(dto);

                var response = new ApiResponseRequest<User>(null!, true, "Password updated successfully");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseRequest<IEnumerable<User>>(null!, false, ex.Message.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Method to renew token
        /// </summary>
        /// <param name="renewTokenDto"></param>
        [Authorize]
        [HttpPut("RenewToken")]
        public async Task<ActionResult> RenewToken()
        {
            try
            {
                // Obtener el header Authorization
                var authHeader = HttpContext.Request.Headers["Authorization"].ToString();

                if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                {
                    return Unauthorized(new ApiResponseRequest<string>(null!, false, "Authorization header is missing or invalid"));
                }

                // Extraer el token quitando el prefijo "Bearer "
                var token = authHeader.Substring("Bearer ".Length).Trim();

                // Pasar el token como string al servicio
                var newToken = await _authService.RenewTokenAsync(token);

                return Ok(new ApiResponseRequest<RenewTokenRequest>(newToken, true, "Token renewed successfully"));
            }
            catch (Exception ex)
            {
                var response = new ApiResponseRequest<RenewTokenRequest>(null!, false, $"Failed to renew token: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}