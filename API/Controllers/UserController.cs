using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Utilities.Email.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public UserController(IPersonService personService, IUserService userService, IEmailService emailService)
        {
            _personService = personService;
            _userService = userService;
            _emailService = emailService;
        }

        /// <summary>
        /// Registrar un nuevo usuario y persona, y enviar correo de bienvenida.
        /// </summary>
        [HttpPost("register-full")]
        public async Task<IActionResult> RegisterFull([FromBody] PersonUserRegisterRequest request)
        {
            try
            {
                // 1. Registrar la persona
                // Map PersonRegisterRequest to PersonRequest
                var personRequest = new PersonRequest
                {
                    // Assign properties from request.Person to personRequest as needed
                    FirstName = request.Person.FirstName,
                    Email = request.Person.Email,
                    // Add other properties as required
                };
                var personResult = await _personService.CreatePersonAsync(personRequest);
                if (personResult == null)
                    return BadRequest("No se pudo crear la persona.");

                // 2. Asignar el Id de la persona creada al usuario (solo en backend)
                var userRequest = request.User;
                // Si UserRegisterRequest no tiene PersonId, usa un DTO interno o asigna aquí antes de guardar
                dynamic userToSave = userRequest;
                userToSave.PersonId = personResult.Id;

                // 3. Registrar el usuario
                var createdUser = await _userService.AddAsync(userToSave);
                if (createdUser == null)
                    return BadRequest("No se pudo crear el usuario.");

                // 4. Leer plantilla y enviar correo
                string templatePath = Path.Combine("Utilities", "Email", "Templates", "Recordatorio.html");
                string body = System.IO.File.ReadAllText(templatePath);
                body = body.Replace("{Nombre}", personResult.FirstName)
                           .Replace("{Fecha}", DateTime.Now.ToString("dd/MM/yyyy"));
                await _emailService.SendExperiencesEmail(personResult.Email, body);

                return Ok(new { person = personResult, user = createdUser });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtener un usuario por nombre
        /// </summary>
        [HttpGet("username/User")]
        public async Task<IActionResult> GetByName(string username)
        {
            try
            {
                var user = await _userService.GetByName(username);
                if (user == null)
                    return NotFound(new { message = "Usuario no encontrado" });

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("{userId}/menu")]
        public async Task<ActionResult<List<MenuRequest>>> GetMenu(int userId)
        {
            var menu = await _userService.GetMenuAsync(userId);
            return Ok(menu);
        }
    }
}
