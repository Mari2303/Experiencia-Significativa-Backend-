using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Repository.Interfaces
{
    /// <summary>
    /// Interface for operations related to base entitys.
    /// This interface defines methods for retrieving, adding, and updating base entitys in the repository.
    /// </summary>
    public interface IBaseModelRepository<T, D, R> where T : BaseModel where D : BaseDTO where R : BaseRequest
    {
        /// <summary>
        /// Retrieves all base entitys.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a collection of <see cref="R"/> results.</returns>
        Task<IEnumerable<R>> GetAll(QueryFilterRequest filters);
        /// <summary>
        /// Retrieves a entity by their ID.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        /// <returns>A task representing the asynchronous operation, with a <see cref="T"/> result.</returns>
        Task<T> GetById(int id);
        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>A task representing the asynchronous operation, with a <see cref="T"/> result.</returns>
        Task<T> Save(T entity);
        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity with updated data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Update(T entity);
        /// <summary>
        /// Deletes an entity based on its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Delete(int id);

        Task Restore(int id);
    }
}