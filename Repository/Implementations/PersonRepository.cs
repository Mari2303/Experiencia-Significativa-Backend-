using AutoMapper;
using Entity.Context;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using Utilities.Helper;

namespace Repository.Implementations
{
    /// <summary>
    /// Implementation of the repository for person-related operations.
    /// </summary>
    public class PersonRepository : BaseModelRepository<Person, PersonDTO, PersonRequest>, IPersonRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<Person, PersonDTO> _helperRepository;

        public PersonRepository(ApplicationContext context, IMapper mapper, IConfiguration configuration, IHelper<Person, PersonDTO> helperRepository)
            : base(context, mapper, configuration, helperRepository)
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
        /// A task that represents the asynchronous operation. The task result contains an <see cref="IEnumerable{PersonResponseDTO}"/> 
        /// representing the list of mapped DTOs that match the applied filters and pagination settings.
        /// </returns>
        /// <exception cref="Exception">
        /// Throws any exception encountered during query execution or data mapping.
        /// </exception>
        public override async Task<IEnumerable<PersonRequest>> GetAll(QueryFilterRequest filters)
        {
            try
            {
                int pageNumber = filters.PageNumber.HasValue && filters.PageNumber.Value > 0 ? filters.PageNumber.Value : _configuration.GetValue<int>("Pagination:DefaultPageNumber");
                int pageSize = filters.PageSize.HasValue && filters.PageSize.Value > 0 ? filters.PageSize.Value : _configuration.GetValue<int>("Pagination:DefaultPageSize");

                filters.ColumnOrder ??= _configuration.GetValue<string>("Ordering:DefaultColumnOrder");
                filters.DirectionOrder ??= _configuration.GetValue<string>("Ordering:DefaultDirectionOrder");

                var sql = @"SELECT
                            person.Id,
                            CASE person.DocumentType
                                WHEN 1 THEN 'Cédula de ciudadanía'
                                WHEN 2 THEN 'Tarjeta de identidad'
                                WHEN 3 THEN 'Cédula de extranjería'

                                ELSE 'Desconocido'
                            END AS DocumentType,
                            person.IdentificationNumber,
                            person.FirstName,
                            person.MiddleName,
                            person.FirstLastName,
                            person.SecondLastName,
                            CONCAT(person.FirstName, ' ' , person.MiddleName, ' ' , person.FirstLastName, ' ' , person.SecondLastName) AS FullName,
                            END AS Gender,
                            person.Email,
                            person.Phone,
                            person.State,
                            person.CreatedAt,
                            person.DeletedAt
                        FROM
                            Persons AS person
                        WHERE person.DeletedAt IS NULL ";

                if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
                {
                    sql += @"AND person." + filters.NameForeignKey + @" = @foreignKey ";
                }

                if (!string.IsNullOrEmpty(filters.Filter))
                {
                    sql += @"AND (UPPER(CONCAT(person.FirstName,person.MiddleName,person.FirstLastName,person.SecondLastName)) LIKE UPPER(CONCAT(%, @filter, %))) ";
                }

                sql += @"ORDER BY person." + filters.ColumnOrder + @" " + filters.DirectionOrder;

                IEnumerable<PersonRequest> items = await _context.QueryAsync<PersonRequest>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

                // Apply pagination
                if (filters.AplyPagination)
                {
                    int skip = (pageNumber - 1) * pageSize;
                    items = items.Skip(skip).Take(pageSize);
                }

                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving data: {ex.Message}");
                throw;
            }
        }
    }
}