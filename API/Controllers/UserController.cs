using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    public class UserController : BaseModelController<User, UserDTO, UserRequest>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IBaseModelService<User, UserDTO, UserRequest> baseService, IUserService service, IMapper mapper) : base(baseService, mapper)
        {
            _userService = service;
            _mapper = mapper;
        }
    


    /// <summary>
/// Registrar un nuevo usuario
/// </summary>
[HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequest request)
        {
            try
            {
                var createdUser = await _userService.AddAsync(request);
                return Ok(createdUser);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        /// <summary>
        /// Obtener un usuario por nombre
        /// </summary>
        [HttpGet("{username}")]
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

    }

    }
