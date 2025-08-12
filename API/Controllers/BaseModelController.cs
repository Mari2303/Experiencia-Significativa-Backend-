using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    /// <summary>
    /// Generic base controller for handling CRUD operations using a service layer and AutoMapper.
    /// </summary>
    /// <typeparam name="T">The entity type, inheriting from <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">The data transfer object (DTO) type, inheriting from <see cref="BaseDTO"/>.</typeparam>
    /// <typeparam name="R">The Request type, inheriting from <see cref="BaseRequest"/>.</typeparam>
    [ApiController]
    [Route("api/[controller]")]
    public class BaseModelController<T, D, R> : ABaseModelController<T, D, R>
        where T : BaseModel
        where D : BaseDTO
        where R : BaseRequest
    {
        private readonly IBaseModelService<T, D, R> _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModelController{T, D, R}"/> class.
        /// </summary>
        /// <param name="service">The service instance used for business logic operations.</param>
        /// <param name="mapper">The AutoMapper instance used to map between entities and DTOs.</param>
        public BaseModelController(IBaseModelService<T, D, R> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all records of the entity as a list of DTOs.
        /// </summary>
        /// <returns>An <see cref="ActionResult"/> containing a list of DTOs or an error message.</returns>
        /// [Authorize] Asegura que el acceso a este método esté restringido a los usuarios que estén autenticados y tengan los permisos adecuados
        [Authorize]
        [HttpGet("getAll")]
        public override async Task<ActionResult<IEnumerable<R>>> GetAll([FromQuery] QueryFilterRequest filters)
        {
            try
            {
                var data = await _service.GetAll(filters);

                if (data == null)
                {
                    var responseNull = new ApiResponseRequest<IEnumerable<R>>(null!, false, "Records not found");
                    return NotFound(responseNull);
                }

                var response = new ApiResponseRequest<IEnumerable<R>>(data, true, "Ok");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseRequest<IEnumerable<R>>(null!, false, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Retrieves a single record by its ID.
        /// </summary>
        /// <param name="id">The ID of the record to retrieve.</param>
        /// <returns>An <see cref="ActionResult"/> containing the DTO or an error message.</returns>
        /// [Authorize] Asegura que el acceso a este método esté restringido a los usuarios que estén autenticados y tengan los permisos adecuados
        [Authorize]
        [HttpGet("{id}")]
        public override async Task<ActionResult<D>> GetById(int id)
        {
            try
            {
                T data = await _service.GetById(id);

                if (data == null)
                {
                    var responseNull = new ApiResponseRequest<D>(null!, false, "Record not found");
                    return NotFound(responseNull);
                }

                var response = new ApiResponseRequest<D>(_mapper.Map<D>(data), true, "Ok");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseRequest<IEnumerable<D>>(null!, false, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Stores a new record based on the provided DTO.
        /// </summary>
        /// <param name="dto">The DTO representing the new record.</param>
        /// <returns>An <see cref="ActionResult"/> with the stored record or an error message.</returns>
        /// [Authorize] Asegura que el acceso a este método esté restringido a los usuarios que estén autenticados y tengan los permisos adecuados
        [Authorize]
        [HttpPost]
        public override async Task<ActionResult<D>> Save(D request)
        {
            try
            {
                T saved = await _service.Save(_mapper.Map<T>(request));

                var response = new ApiResponseRequest<D>(request, true, "Record stored successfully");

                return new CreatedAtRouteResult(new { id = saved.Id }, response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseRequest<IEnumerable<D>>(null!, false, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Updates an existing record with the data from the provided DTO.
        /// </summary>
        /// <param name="dto">The DTO containing updated data.</param>
        /// <returns>An <see cref="ActionResult"/> with the updated record or an error message.</returns>
        /// [Authorize] Asegura que el acceso a este método esté restringido a los usuarios que estén autenticados y tengan los permisos adecuados
        [Authorize]
        [HttpPut]
        public override async Task<ActionResult<D>> Update(D request)
        {
            try
            {
                await _service.Update(_mapper.Map<T>(request));

                var response = new ApiResponseRequest<D>(request, true, "Record updated successfully");

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseRequest<IEnumerable<D>>(null!, false, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Deletes a record by its ID.
        /// </summary>
        /// <param name="id">The ID of the record to delete.</param>
        /// <returns>An <see cref="ActionResult"/> indicating the result of the operation.</returns>
        /// [Authorize] Asegura que el acceso a este método esté restringido a los usuarios que estén autenticados y tengan los permisos adecuados
        [Authorize]
        [HttpDelete("{id}")]
        public override async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);

                var successResponse = new ApiResponseRequest<D>(null!, true, "Record successfully deleted");
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponseRequest<D>(null!, false, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
