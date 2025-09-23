using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Abstract base controller that defines generic RESTful endpoints for managing entities and their DTO representations.
    /// This class is intended to be inherited by specific controllers that handle a concrete model type.
    /// </summary>
    /// <typeparam name="T">The entity type, inheriting from <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">The DTO type, inheriting from <see cref="BaseDTO"/>.</typeparam>
    /// <typeparam name="R">The Request type, inheriting from <see cref="BaseRequest"/>.</typeparam>
    public abstract class ABaseModelController<T, D, R> : ControllerBase
        where T : BaseModel
        where D : BaseDTO
        where R : BaseRequest
    {
        /// <summary>
        /// Retrieves all entities as a collection of DTOs.
        /// </summary>
        /// <returns>A list of <typeparamref name="R"/> wrapped in an <see cref="ActionResult"/>.</returns>
        public abstract Task<ActionResult<IEnumerable<R>>> GetAll(QueryFilterRequest filters);

        /// <summary>
        /// Retrieves a specific entity by its unique identifier and maps it to a DTO.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>The DTO representation of the entity, wrapped in an <see cref="ActionResult"/>.</returns>
        public abstract Task<ActionResult<D>> GetById(int id);

        /// <summary>
        /// Creates a new entity using the data from the provided DTO.
        /// </summary>
        /// <param name="dto">The data transfer object containing entity data to save.</param>
        /// <returns>The created entity as a DTO, wrapped in an <see cref="ActionResult"/>.</returns>
        public abstract Task<ActionResult<D>> Save(D request);

        /// <summary>
        /// Updates an existing entity using the data from the provided DTO.
        /// </summary>
        /// <param name="dto">The data transfer object containing the updated entity data.</param>
        /// <returns>An <see cref="ActionResult"/> indicating the outcome of the update operation.</returns>
        public abstract Task<ActionResult<D>> Update(D request);

        /// <summary>
        /// Deletes an entity based on its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>An <see cref="ActionResult"/> indicating the outcome of the deletion operation.</returns>
        public abstract Task<ActionResult> Delete(int id);


        public abstract Task<ActionResult> Restore(int id);
    }
}
