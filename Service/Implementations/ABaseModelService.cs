using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Service.Interfaces;

namespace Service.Implementations
{
    /// <summary>
    /// Abstract base class that defines the structure for a service layer handling generic CRUD operations.
    /// This class must be inherited and its methods implemented by a concrete service.
    /// </summary>
    /// <typeparam name="T">The entity type, which must inherit from <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">The DTO type, which must inherit from <see cref="BaseDTO"/>.</typeparam>
    /// <typeparam name="R">The data transfer object (Request) type, which must inherit from <see cref="BaseRequest"/>.</typeparam>
    public abstract class ABaseModelService<T, D, R> : IBaseModelService<T, D, R>
        where T : BaseModel
        where D : BaseDTO
        where R : BaseRequest
    {
        /// <summary>
        /// Deletes an entity from the data store based on its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public abstract Task Delete(int id);

        /// <summary>
        /// Retrieves all entities and maps them to DTOs.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing a list of DTOs.</returns>
        public abstract Task<IEnumerable<R>> GetAll(QueryFilterRequest filters);

        /// <summary>
        /// Retrieves a single entity based on its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation, containing the entity if found.</returns>
        public abstract Task<T> GetById(int id);

        /// <summary>
        /// Saves a new entity to the data store.
        /// </summary>
        /// <param name="entity">The entity to save.</param>
        /// <returns>A task that represents the asynchronous operation, containing the saved entity.</returns>
        public abstract Task<T> Save(T entity);

        /// <summary>
        /// Updates an existing entity in the data store.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public abstract Task Update(T entity);
    }
}
