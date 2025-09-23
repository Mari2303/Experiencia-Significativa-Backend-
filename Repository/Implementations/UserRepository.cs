using AutoMapper;
using Entity.Context;
using Entity.Dtos;
using Entity.Requests;
using Entity.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Utilities.Helper;
using System.Text;
using System.Security.Cryptography;

namespace Repository.Implementations
{
    /// <summary>
    /// Implementation of the repository for user-related operations.
    /// </summary>
    public class UserRepository : BaseModelRepository<User, UserDTO, UserRequest>, IUserRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<User, UserDTO> _helperRepository;

        public UserRepository(ApplicationContext context, IMapper mapper, IConfiguration configuration, IHelper<User, UserDTO> helperRepository) : base(context, mapper, configuration, helperRepository)
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
        /// A task that represents the asynchronous operation. The task result contains an <see cref="IEnumerable{UserDTO}"/> 
        /// representing the list of mapped DTOs that match the applied filters and pagination settings.
        /// </returns>
        /// <exception cref="Exception">
        /// Throws any exception encountered during query execution or data mapping.
        /// </exception>
        public override async Task<IEnumerable<UserRequest>> GetAll(QueryFilterRequest filters)
        {
            try
            {
                int pageNumber = filters.PageNumber.HasValue && filters.PageNumber.Value > 0 ? filters.PageNumber.Value : _configuration.GetValue<int>("Pagination:DefaultPageNumber");
                int pageSize = filters.PageSize.HasValue && filters.PageSize.Value > 0 ? filters.PageSize.Value : _configuration.GetValue<int>("Pagination:DefaultPageSize");

                filters.ColumnOrder ??= _configuration.GetValue<string>("Ordering:DefaultColumnOrder");
                filters.DirectionOrder ??= _configuration.GetValue<string>("Ordering:DefaultDirectionOrder");

                var sql = @"SELECT
                            usu.Id,
                            usu.State,
                            usu.CreatedAt,
                            usu.DeletedAt,
                            usu.Code,
                            usu.Username,
                            usu.PersonId,
                            usu.Password,
                            CONCAT(person.FirstName,' ', person.FirstLastName) AS Person
                        FROM
                            Users AS usu
                        INNER JOIN Persons AS person ON usu.PersonId = person.Id
                        WHERE usu.DeletedAt IS NULL ";

                if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
                {
                    sql += @"AND usu." + filters.NameForeignKey + @" = @foreignKey ";
                }

                if (!string.IsNullOrEmpty(filters.Filter))
                {
                    sql += @"AND (UPPER(CONCAT(usu.Username)) LIKE UPPER(CONCAT(%, @filter, %))) ";
                }

                sql += @"ORDER BY usu." + filters.ColumnOrder + @" " + filters.DirectionOrder;

                IEnumerable<UserRequest> items = await _context.QueryAsync<UserRequest>(sql, new { filter = filters.Filter, foreignKey = filters.ForeignKey });

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

        public async Task<UserRequest> GetByName(string name)
        {
            try
            {
                var sql = @"SELECT
                            usu.Id,
                            usu.State,
                            usu.CreatedAt,
                            usu.DeletedAt,
                            usu.Code,
                            usu.Username,
                            usu.PersonId,
                            usu.Password,
                            CONCAT(person.FirstName,' ', person.FirstLastName) AS Person
                        FROM
                            Users AS usu
                        INNER JOIN Persons AS person ON usu.PersonId = person.Id
                        WHERE usu.Username = @username AND usu.DeletedAt IS NULL";

                return await _context.QueryFirstOrDefaultAsync<UserRequest>(sql, new { username = name });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving data: {ex.Message}");
                throw;
            }
        }

        public async Task<List<MenuRequest>> GetMenuAsync(int userId)
        {
            try
            {
                return await (
                    from u in _context.Users
                    join ur in _context.UserRoles on u.Id equals ur.UserId
                    join rfp in _context.RoleFormPermissions on ur.RoleId equals rfp.RoleId
                    join f in _context.Forms on rfp.FormId equals f.Id
                    join fm in _context.FormModules on f.Id equals fm.FormId
                    join m in _context.Modules on fm.ModuleId equals m.Id
                    where u.Id == userId
                    orderby f.Order
                    select new MenuRequest
                    {
                        FormId = f.Id,
                        Form = f.Name,
                        Path = f.Path,
                        Icon = f.Icon,
                        Order = f.Order,
                        ModuleId = m.Id,
                        Module = m.Name
                    }
                ).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving menu: {ex.Message}");
                throw;
            }
        }


        //  este AddAsync trabaja con ENTIDAD User
        public async Task AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<List<string>> GetRolesByUserId(int userId)
        {
            var roles = await _context.Users
               .Where(u => u.Id == userId)
               .Include(u => u.UserRoles)
                   .ThenInclude(ur => ur.Role)
               .SelectMany(u => u.UserRoles.Select(ur => ur.Role.Name))
               .ToListAsync();

            return roles;
        }


        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Person) // si tienes la navegación
                .FirstOrDefaultAsync(u => u.Person != null && u.Person.Email == email);
        }


        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }








    }

}

