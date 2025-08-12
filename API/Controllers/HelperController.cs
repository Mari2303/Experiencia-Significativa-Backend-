using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelperController : AHelperController
    {
        private readonly IHelperService<BaseModel, BaseDTO> _helperService;
        private readonly IMapper _mapper;

        public HelperController(IHelperService<BaseModel, BaseDTO> helperService, IMapper mapper)
        {
            _helperService = helperService;
            _mapper = mapper;
        }
        
        [Authorize]
        [HttpGet("{enumName}")]
        public override async Task<ActionResult<IEnumerable<DataSelectRequest>>> GetEnum(string enumName)
        {
            try
            {
                var data = await _helperService.GetEnum(enumName);

                if (data == null)
                {
                    var responseNull = new ApiResponseRequest<IEnumerable<DataSelectRequest>>(null!, false, "Records not found");
                    return NotFound(responseNull);
                }

                var response = new ApiResponseRequest<IEnumerable<DataSelectRequest>>(data, true, "Ok");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseRequest<IEnumerable<DataSelectRequest>>(null!, false, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}