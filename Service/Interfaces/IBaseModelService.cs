using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Service.Interfaces
{
    /// <summary>
    /// Defines the contract for a generic service layer that performs basic CRUD operations 
    /// on entities and their corresponding Data Transfer Objects (DTOs).
    /// </summary>
    /// <typeparam name="T">The entity type, which must inherit from <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">The DTO type, which must inherit from <see cref="BaseDTO"/>.</typeparam>
    /// <typeparam name="R">The DTO type, which must inherit from <see cref="BaseRequest"/>.</typeparam>
    public interface IBaseModelService<T, D, R>
        where T : BaseModel
        where D : BaseDTO
        where R : BaseRequest
    {
        /// <summary>
        /// Retrieves all records of the entity type and maps them to DTOs.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing a collection of DTOs.</returns>
        Task<IEnumerable<R>> GetAll(QueryFilterRequest filters);

        /// <summary>
        /// Retrieves a specific entity by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation, containing the entity if found.</returns>
        Task<T> GetById(int id);

        /// <summary>
        /// Persists a new entity to the underlying data store.
        /// </summary>
        /// <param name="entity">The entity to be saved.</param>
        /// <returns>A task that represents the asynchronous operation, containing the saved entity.</returns>
        Task<T> Save(T entity);

        /// <summary>
        /// Updates an existing entity in the data store.
        /// </summary>
        /// <param name="entity">The entity with updated values.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Update(T entity);

        /// <summary>
        /// Deletes an entity based on its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Delete(int id);
    }
}
