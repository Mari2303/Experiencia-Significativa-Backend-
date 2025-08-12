using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Repository.Interfaces;

namespace Service.Implementations
{
    /// <summary>
    /// Concrete implementation of the generic service layer for handling standard CRUD operations.
    /// </summary>
    /// <typeparam name="T">The entity type, inheriting from <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">The data transfer object (DTO) type, inheriting from <see cref="BaseDTO"/>.</typeparam>
    /// <typeparam name="R">The data transfer object (Request) type, which must inherit from <see cref="BaseRequest"/>.</typeparam>
    public class BaseModelService<T, D, R> : ABaseModelService<T, D, R>
        where T : BaseModel
        where D : BaseDTO
        where R : BaseRequest
    {
        private readonly IBaseModelRepository<T, D, R> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModelService{T, D, R}"/> class.
        /// </summary>
        /// <param name="repository">The repository instance used for data persistence.</param>
        /// <param name="mapper">The AutoMapper instance used to map entities and DTOs.</param>
        public BaseModelService(IBaseModelRepository<T, D, R> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Marks an entity as deleted by setting the DeletedAt timestamp and disabling its state.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to logically delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="Exception">Thrown if the entity is not found.</exception>
        public override async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        /// <summary>
        /// Retrieves all records from the repository as DTOs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, containing a list of DTOs.</returns>
        public override async Task<IEnumerable<R>> GetAll(QueryFilterRequest filters)
        {
            return await _repository.GetAll(filters);
        }

        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, containing the entity if found.</returns>
        public override async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        /// <summary>
        /// Saves a new entity to the repository, initializing CreatedAt and State properties.
        /// </summary>
        /// <param name="entity">The entity to be saved.</param>
        /// <returns>A task representing the asynchronous operation, containing the saved entity.</returns>
        public override async Task<T> Save(T entity)
        {
            return await _repository.Save(entity);
        }

        /// <summary>
        /// Updates an existing entity in the repository, setting the UpdatedAt timestamp.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override async Task Update(T entity)
        {
            await _repository.Update(entity);
        }
    }
}
