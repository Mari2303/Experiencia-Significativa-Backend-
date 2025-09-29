using AutoMapper;
using Entity.Context;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Repository.Implementations;
using Repository.Interfaces;
using Utilities.Helper;

namespace Repository.Implementations
{
    /// <summary>
    /// Concrete implementation of the abstract repository for performing generic CRUD operations.
    /// </summary>
    /// <typeparam name="T">The entity type, which must inherit from <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">The data transfer object (DTO) type, which must inherit from <see cref="BaseDTO"/>.</typeparam>
    /// <typeparam name="R">The data transfer object (Request) type, which must inherit from <see cref="BaseRequest"/>.</typeparam>
    public class BaseModelRepository<T, D, R> : ABaseModelRepository<T, D, R>
        where T : BaseModel
        where D : BaseDTO
        where R : BaseRequest
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<T, D> _helperRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModelRepository{T, D, R}"/> class.
        /// </summary>
        /// <param name="context">The database context for accessing entity sets.</param>
        /// <param name="mapper">The AutoMapper instance used to map between entity and DTO types.</param>
        public BaseModelRepository(ApplicationContext context, IMapper mapper, IConfiguration configuration, IHelper<T, D> helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _helperRepository = helperRepository;
        }

        /// <summary>
        /// Retrieves (where State is true) a filtered, sorted, and paginated list of DTOs based on the specified query filters.
        /// </summary>
        /// <param name="filters">
        /// An instance of <see cref="QueryFilterRequest"/> containing optional parameters for filtering, 
        /// ordering, pagination, and foreign key constraints.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an <see cref="IEnumerable{D}"/> 
        /// representing the list of mapped DTOs that match the applied filters and pagination settings.
        /// </returns>
        /// <exception cref="Exception">
        /// Throws any exception encountered during query execution or data mapping.
        /// </exception>
        public override async Task<IEnumerable<R>> GetAll(QueryFilterRequest filters)
        {
            // Set default values if not provided
            int pageNumber = filters.PageNumber.HasValue && filters.PageNumber.Value > 0 ? filters.PageNumber.Value : _configuration.GetValue<int>("Pagination:DefaultPageNumber");
            int pageSize = filters.PageSize.HasValue && filters.PageSize.Value > 0 ? filters.PageSize.Value : _configuration.GetValue<int>("Pagination:DefaultPageSize");

            filters.ColumnOrder ??= _configuration.GetValue<string>("Ordering:DefaultColumnOrder");
            filters.DirectionOrder ??= _configuration.GetValue<string>("Ordering:DefaultDirectionOrder");

            try
            {
                // Retrieves (Where State is true)
              IQueryable<T> query = _context.Set<T>();

// Aplica filtro por estado si viene en el request
if (filters.OnlyActive.HasValue)
{
    if (filters.OnlyActive.Value)
        query = query.Where(x => x.State);          // Solo activos
    else
        query = query.Where(x => !x.State);         // Solo inactivos
}

                // Apply Foreign Key Filters
                if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
                {
                    query = query.Where(i => EF.Property<int>(i, filters.NameForeignKey) == filters.ForeignKey);
                }

                // Apply Dynamic Filters
                if (!string.IsNullOrEmpty(filters.Filter))
                {
                    query = PagedListRequest<T>.ApplyDynamicFilters(query, filters);
                }

                // Apply Ordering
                query = PagedListRequest<T>.ApplyOrdering(query, filters);

                // Apply pagination
                if (filters.AplyPagination) {
                    int skip = (pageNumber - 1) * pageSize;
                    query = query.Skip(skip).Take(pageSize);
                }

                var lstModel = await query.ToListAsync();
                var lstDto = lstModel.Select(item => _mapper.Map<R>(item)).ToList();

                return lstDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving data: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, containing the entity of type <typeparamref name="T"/> if found; otherwise, null.</returns>
        public override async Task<T> GetById(int id)
        {
            try
            {
                return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving data: {ex.Message}");
                throw;
            }
        }



        // Iniciar transacción
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }




        // Guardar entidad genérica
        public async Task<T> SaveAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        /// <summary>
        /// Saves a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to be saved.</param>
        /// <returns>A task representing the asynchronous operation, containing the saved entity.</returns>
        public override async Task<T> Save(T entity)
        {
            try
            {
                // Set default properties for the entity
                entity.CreatedAt = DateTime.UtcNow.AddHours(-5);
                entity.State = true;

                // Check if the entity has the 'Code' property (using reflection)
                var codeProperty = typeof(T).GetProperty("Code");
                if (codeProperty != null && codeProperty.CanWrite)
                {
                    // If the entity has the 'Code' property, generate a consecutive code using the helper service
                    string generatedCode = await _helperRepository.GenerateConsecutiveCode();
                    codeProperty.SetValue(entity, generatedCode); // Set the generated code
                }

                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
                throw;
            }
        }
        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override async Task Update(T entityUpdated)
        {
            try
            {
                T entity = await GetById(entityUpdated.Id);
                entityUpdated.CreatedAt = entity.CreatedAt;

                _context.Entry(entityUpdated).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _context.Entry(entityUpdated).State = EntityState.Detached;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating data: {ex.Message}");
                throw;
            }
        }
        /// <summary>
        /// Marks an entity as deleted by setting the DeletedAt timestamp and disabling its state.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to logically delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="Exception">Thrown if the entity is not found.</exception>
        public override async Task Delete(int id)
        {
            bool validateRelationships = await _helperRepository.ValidateEntityRelationships(id);
            if (validateRelationships)
            {
                T entity = await GetById(id);

                entity.DeletedAt = DateTime.UtcNow.AddHours(-5);
                entity.State = false;
                await Update(entity);
            }
            else
            {
                throw new Exception("Related entities found, entity cannot be deleted");
            }
        }



        public override async Task Restore(int id)
        {
            T entity = await GetById(id);

            if (entity == null)
                throw new Exception("Entity not found");

            entity.DeletedAt = null;  // Se limpia la fecha de eliminación
            entity.State = true;      // Se vuelve a marcar como activo

            await Update(entity);
        }





    }
}
