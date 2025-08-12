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
    /// Implementation of the repository for user role assignment operations.
    /// </summary>
    public class UserRoleRepository : BaseModelRepository<UserRole, UserRoleDTO, UserRoleRequest>, IUserRoleRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<UserRole, UserRoleDTO> _helperRepository;

        public UserRoleRepository(ApplicationContext context, IMapper mapper, IConfiguration configuration, IHelper<UserRole, UserRoleDTO> helperRepository) : base(context, mapper, configuration, helperRepository)
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
        /// A task that represents the asynchronous operation. The task result contains an <see cref="IEnumerable{UserRoleRequest}"/> 
        /// representing the list of mapped DTOs that match the applied filters and pagination settings.
        /// </returns>
        /// <exception cref="Exception">
        /// Throws any exception encountered during query execution or data mapping.
        /// </exception>
        public override async Task<IEnumerable<UserRoleRequest>> GetAll(QueryFilterRequest filters)
        {
            try
            {
                int pageNumber = filters.PageNumber.HasValue && filters.PageNumber.Value > 0 ? filters.PageNumber.Value : _configuration.GetValue<int>("Pagination:DefaultPageNumber");
                int pageSize = filters.PageSize.HasValue && filters.PageSize.Value > 0 ? filters.PageSize.Value : _configuration.GetValue<int>("Pagination:DefaultPageSize");

                filters.ColumnOrder ??= _configuration.GetValue<string>("Ordering:DefaultColumnOrder");
                filters.DirectionOrder ??= _configuration.GetValue<string>("Ordering:DefaultDirectionOrder");
                
                var sql = @"SELECT
                            userRol.Id,
                            userRol.UserId,
                            userRol.RoleId,
                            u.Username AS User,
                            r.Name AS Role
                        FROM
                            UserRoles AS userRol
                        INNER JOIN Users AS u ON userRol.UserId = u.Id 
                        INNER JOIN Roles AS r ON userRol.RoleId = r.Id 
                        WHERE userRol.DeletedAt IS NULL ";

                if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
                {
                    sql += @"AND userRol." + filters.NameForeignKey + @" = @foreignKey ";
                }

                if (!string.IsNullOrEmpty(filters.Filter))
                {
                    sql += @"AND (UPPER(CONCAT(u.Username, r.Name)) LIKE UPPER(CONCAT(%, @filter, %))) ";
                }

                sql += @"ORDER BY userRol." + filters.ColumnOrder + @" " + filters.DirectionOrder;

                IEnumerable<UserRoleRequest> items = await _context.QueryAsync<UserRoleRequest>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

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
