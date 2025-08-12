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
    /// Implementation of the repository for role, form, and permission operations.
    /// </summary>
    public class RoleFormPermissionRepository : BaseModelRepository<RoleFormPermission, RoleFormPermissionDTO, RoleFormPermissionRequest>, IRoleFormPermissionRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<RoleFormPermission, RoleFormPermissionDTO> _helperRepository;

        public RoleFormPermissionRepository(ApplicationContext context, IMapper mapper, IConfiguration configuration, IHelper<RoleFormPermission, RoleFormPermissionDTO> helperRepository) : base(context, mapper, configuration, helperRepository)
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
        /// An instance of <see cref="QueryFilterDTO"/> containing optional parameters for filtering, 
        /// ordering, pagination, and foreign key constraints.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an <see cref="IEnumerable{RoleFormPermissionRequest}"/> 
        /// representing the list of mapped DTOs that match the applied filters and pagination settings.
        /// </returns>
        /// <exception cref="Exception">
        /// Throws any exception encountered during query execution or data mapping.
        /// </exception>
        public override async Task<IEnumerable<RoleFormPermissionRequest>> GetAll(QueryFilterRequest filters)
        {
            try
            {
                int pageNumber = filters.PageNumber.HasValue && filters.PageNumber.Value > 0 ? filters.PageNumber.Value : _configuration.GetValue<int>("Pagination:DefaultPageNumber");
                int pageSize = filters.PageSize.HasValue && filters.PageSize.Value > 0 ? filters.PageSize.Value : _configuration.GetValue<int>("Pagination:DefaultPageSize");

                filters.ColumnOrder ??= _configuration.GetValue<string>("Ordering:DefaultColumnOrder");
                filters.DirectionOrder ??= _configuration.GetValue<string>("Ordering:DefaultDirectionOrder");
                
                var sql = @"SELECT
                            roleFormPermissions.Id,
                            roleFormPermissions.RoleId,
                            roleFormPermissions.FormId,
                            roleFormPermissions.PermissionId,
                            r.Name AS Role,
                            f.Name AS Form,
                            p.Name AS Permission
                        FROM
                            RoleFormPermissions AS roleFormPermissions
                        INNER JOIN Roles AS r ON roleFormPermissions.RoleId = r.Id 
                        INNER JOIN Forms AS f ON roleFormPermissions.FormId = f.Id
                        INNER JOIN Permissions AS p ON roleFormPermissions.PermissionId = p.Id
                        WHERE roleFormPermissions.DeletedAt IS NULL ";

                if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
                {
                    sql += @"AND roleFormPermissions." + filters.NameForeignKey + @" = @foreignKey ";
                }

                if (!string.IsNullOrEmpty(filters.Filter))
                {
                    sql += @"AND (UPPER(CONCAT()) LIKE UPPER(CONCAT(%, @filter, %))) ";
                }

                sql += @"ORDER BY roleFormPermissions." + filters.ColumnOrder + @" " + filters.DirectionOrder;

                IEnumerable<RoleFormPermissionRequest> items = await _context.QueryAsync<RoleFormPermissionRequest>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

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
