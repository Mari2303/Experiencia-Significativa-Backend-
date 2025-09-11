using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class ExperienceController : BaseModelController<Experience, ExperienceDTO, ExperienceRequest>
    {
        private readonly IExperienceService _experienceService;
        private readonly IMapper _mapper;
        public ExperienceController(IBaseModelService<Experience, ExperienceDTO, ExperienceRequest> baseService, IExperienceService experienceService, IMapper mapper) : base(baseService, mapper)
        {
            _experienceService = experienceService;
            _mapper = mapper;
        }


        [Authorize]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ExperienceRegisterDTO dto)
        {
            if (dto == null)
                return BadRequest("El DTO no puede estar vacío.");

            try
            {
                var experience = await _experienceService.RegisterExperienceAsync(dto);
                return Ok(experience);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Ocurrió un error al registrar la experiencia: {ex.Message}");
            }
        }
    }
}


    

