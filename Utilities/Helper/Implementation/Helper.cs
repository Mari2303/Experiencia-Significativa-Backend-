using AutoMapper;
using Entity.Context;
using Entity.Dtos;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using System.ComponentModel;
using Entity.Requests;

namespace Utilities.Helper
{
    /// <summary>
    /// Concrete implementation of the <see cref="AHelper{T, D}"/> that uses reflection and expression trees
    /// to dynamically validate whether an entity of type <typeparamref name="T"/> is referenced by other active entities in the database.
    /// </summary>
    /// <typeparam name="T">The entity type, which must inherit from <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">The DTO type, which must inherit from <see cref="BaseDTO"/>.</typeparam>
    public class Helper<T, D> : AHelper<T, D>
        where T : BaseModel
        where D : BaseDTO
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Helper{T, D}"/> class with the specified database context and mapper.
        /// </summary>
        /// <param name="context">The Entity Framework database context used for querying entity relationships.</param>
        /// <param name="mapper">The object mapper used for model-to-DTO transformations.</param>
        public Helper(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Validates whether the entity of type <typeparamref name="T"/> with the given ID is referenced by any active records
        /// in other entities within the current DbContext.
        /// </summary>
        /// <param name="id">The identifier of the entity to validate.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result is <c>true</c> if no active foreign key dependencies exist; 
        /// otherwise, <c>false</c>.
        /// </returns>
        public override async Task<bool> ValidateEntityRelationships(int id)
        {
            var targetEntityName = typeof(T).Name;

            foreach (var entityType in _context.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;
                var properties = clrType.GetProperties();

                var navigationExists = properties.Any(p =>
                    p.PropertyType == typeof(T) ||
                    p.PropertyType.IsClass && p.PropertyType.Name == targetEntityName);

                if (!navigationExists)
                    continue;

                var fkProperty = properties.FirstOrDefault(p =>
                    p.Name == targetEntityName + "Id" && p.PropertyType == typeof(int));

                var stateProperty = properties.FirstOrDefault(p =>
                    p.Name == "State" && p.PropertyType == typeof(bool));

                if (fkProperty == null || stateProperty == null)
                    continue;

                var setMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set), Type.EmptyTypes);
                var genericSetMethod = setMethod!.MakeGenericMethod(clrType);
                var dbSet = genericSetMethod.Invoke(_context, null);
                var queryable = dbSet as IQueryable;

                if (queryable == null)
                    continue;

                var parameter = Expression.Parameter(clrType, "x");
                var propertyFk = Expression.Property(parameter, fkProperty);
                var propertyState = Expression.Property(parameter, stateProperty);

                var constantId = Expression.Constant(id);
                var constantTrue = Expression.Constant(true);

                var fkEquals = Expression.Equal(propertyFk, constantId);
                var stateEquals = Expression.Equal(propertyState, constantTrue);

                var combinedCondition = Expression.AndAlso(fkEquals, stateEquals);
                var lambda = Expression.Lambda(combinedCondition, parameter);

                var whereMethod = typeof(Queryable)
                    .GetMethods()
                    .First(m => m.Name == "Where" && m.GetParameters().Length == 2)
                    .MakeGenericMethod(clrType);

                var filteredQuery = whereMethod.Invoke(null, new object[] { queryable, lambda });

                var toListAsyncMethod = typeof(EntityFrameworkQueryableExtensions)
                    .GetMethods(BindingFlags.Public | BindingFlags.Static)
                    .First(m => m.Name == "ToListAsync" && m.GetParameters().Length == 2)
                    .MakeGenericMethod(clrType);

                var task = (Task)toListAsyncMethod.Invoke(null, new object[] { filteredQuery, CancellationToken.None })!;
                await task.ConfigureAwait(false);

                var resultProperty = task.GetType().GetProperty("Result");
                var list = resultProperty!.GetValue(task) as IEnumerable<object>;

                if (list!.Any())
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Generates a consecutive code by delegating the logic to the repository layer.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the generated 
        /// consecutive code as a 4-digit string (e.g., "0001", "0002").
        /// </returns>
        public override async Task<string> GenerateConsecutiveCode()
        {
            var lastCodeStr = await _context.Set<T>().AsNoTracking().Where(e => EF.Property<string>(e, "Code") != null).Select(e => EF.Property<string>(e, "Code")).ToListAsync();
            var lastCodeInt = lastCodeStr.Select(code =>
            {
                bool isParsed = int.TryParse(code, out int val);
                return (isParsed, val);
            }).Where(x => x.isParsed).Select(x => x.val).DefaultIfEmpty(0).Max();

            int newCode = lastCodeInt + 1;
            return newCode.ToString("D4");
        }
        /// <summary>
        /// Retrieves a list of key-value pairs representing the values of the specified enum.
        /// It uses reflection to locate the enum by name in the <c>Entity.Models</c> namespace and extracts its numeric value and associated <see cref="DescriptionAttribute"/>.
        /// </summary>
        /// <param name="enumName">The name of the enum to retrieve, such as "DocumentType" or "Gender".</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is a list of <see cref="DataSelectRequest"/> containing the enum's value (as <c>Id</c>) and its description (as <c>DisplayText</c>).
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if the enum type is not found or is not a valid enumeration.</exception>
        public override async Task<List<DataSelectRequest>> GetEnum(string enumName)
        {
            var enumType = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).FirstOrDefault(t => t.IsEnum && t.Name.Equals(enumName, StringComparison.OrdinalIgnoreCase));

            if (enumType == null || !enumType.IsEnum)
                throw new ArgumentException($"Enum '{enumName}' not found or not a valid enum.");

            var result = new List<DataSelectRequest>();

            foreach (var value in Enum.GetValues(enumType))
            {
                var memberInfo = enumType.GetMember(value.ToString()!);
                var description = memberInfo[0].GetCustomAttribute<DescriptionAttribute>()?.Description ?? value.ToString();

                result.Add(new DataSelectRequest
                {
                    Id = (int)value,
                    DisplayText = description!
                });
            }

            return result;
        }

        public override async Task<bool> ValidateDataImport(D request)
        {
            if (request == null) return false;

            // Inherited properties that are allowed to be null/empty
            var excludedProps = typeof(BaseDTO)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(p => p.Name)
                .ToHashSet();

            // Properties of the derived class
            var propsToValidate = typeof(D)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => !excludedProps.Contains(p.Name));

            foreach (var prop in propsToValidate)
            {
                var value = prop.GetValue(request);

                if (value == null)
                    return false;

                if (prop.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(value.ToString()))
                    return false;
            }

            return true;
        }
    }
}
