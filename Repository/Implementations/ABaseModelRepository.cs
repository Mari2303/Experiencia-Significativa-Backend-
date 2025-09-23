using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Repository.Interfaces;

namespace Repository.Implementations
{
    /// <summary>
    /// Abstract base repository class that defines generic operations for data access layers.
    /// </summary>
    /// <typeparam name="T">The entity type, which must inherit from <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">The data transfer object (DTO) type, which must inherit from <see cref="BaseDTO"/>.</typeparam>
    /// <typeparam name="R">The data transfer object (Request) type, which must inherit from <see cref="BaseRequest"/>.</typeparam>
    public abstract class ABaseModelRepository<T, D, R> : IBaseModelRepository<T, D, R>
        where T : BaseModel
        where D : BaseDTO
        where R : BaseRequest
    {
        /// <summary>
        /// Retrieves all entities as a collection of DTOs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, containing a collection of <typeparamref name="R"/>.</returns>
        public abstract Task<IEnumerable<R>> GetAll(QueryFilterRequest filters);
        /// <summary>
        /// Retrieves a single entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>A task representing the asynchronous operation, containing the entity of type <typeparamref name="T"/>.</returns>
        public abstract Task<T> GetById(int id);
        /// <summary>
        /// Saves a new entity to the data store.
        /// </summary>
        /// <param name="entity">The entity of type <typeparamref name="T"/> to be saved.</param>
        /// <returns>A task representing the asynchronous operation, containing the saved entity.</returns>
        public abstract Task<T> Save(T entity);
        /// <summary>
        /// Updates an existing entity in the data store.
        /// </summary>
        /// <param name="entity">The entity of type <typeparamref name="T"/> to be updated.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public abstract Task Update(T entity);
        /// <summary>
        /// Deletes an entity from the data store based on its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public abstract Task Delete(int id);



        public abstract Task Restore(int id);
    }
}
