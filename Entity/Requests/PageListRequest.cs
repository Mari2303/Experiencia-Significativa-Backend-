using Entity.Requests;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Entity.Requests
{
    /// <summary>
    /// Represents a paginated list of items with metadata for navigation and optional filtered lists.
    /// Inherits from <see cref="List{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of items in the paginated list.</typeparam>
    public class PagedListRequest<T> : List<T>
    {
        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the size of each page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total number of items across all pages.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets additional related data, such as select lists or filters.
        /// </summary>
        public object Lists { get; set; }

        /// <summary>
        /// Gets a value indicating whether there is a previous page.
        /// </summary>
        public bool HasPreviousPage => CurrentPage > 1;

        /// <summary>
        /// Gets a value indicating whether there is a next page.
        /// </summary>
        public bool HasNextPage => CurrentPage < TotalPages;

        /// <summary>
        /// Gets the next page number if available; otherwise, null.
        /// </summary>
        public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : null;

        /// <summary>
        /// Gets the previous page number if available; otherwise, null.
        /// </summary>
        public int? PreviousPageNumber => HasPreviousPage ? CurrentPage - 1 : null;

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedListDTO{T}"/> class.
        /// </summary>
        /// <param name="items">The items to include in the current page.</param>
        /// <param name="count">The total number of items in the full list.</param>
        /// <param name="pageNumber">The current page number (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="lists">Optional related lists or metadata.</param>
        public PagedListRequest(List<T> items, int count, int pageNumber = 1, int pageSize = 10, object lists = null)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Lists = lists;

            AddRange(items);
        }

        /// <summary>
        /// Creates a new <see cref="PagedListDTO{T}"/> from a source collection, applying pagination logic.
        /// </summary>
        /// <param name="source">The full source collection.</param>
        /// <param name="pageNumber">The page number to return.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="lists">Optional related data to include.</param>
        /// <returns>A paged list of items from the source.</returns>
        public static PagedListRequest<T> Create(IEnumerable<T> source, int pageNumber, int pageSize, object lists = null)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedListRequest<T>(items, count, pageNumber, pageSize, lists);
        }

        /// <summary>
        /// Applies dynamic filtering to the source collection using the specified column and filter string.
        /// </summary>
        /// <param name="query">The source collection to filter.</param>
        /// <param name="queryFilterDto">The filtering criteria.</param>
        /// <returns>A filtered collection of items.</returns>
        public static IQueryable<T> ApplyDynamicFilters(IQueryable<T> query, QueryFilterRequest queryFilterDto)
        {
            return query.Where(i => EF.Property<string>(i, queryFilterDto.ColumnFilter).Contains(queryFilterDto.Filter));
        }

        /// <summary>
        /// Applies dynamic ordering to the source collection using the specified column and direction.
        /// </summary>
        /// <param name="query">The source collection to sort.</param>
        /// <param name="queryFilterDto">The sorting criteria.</param>
        /// <returns>An ordered queryable collection.</returns>
        public static IOrderedQueryable<T> ApplyOrdering(IEnumerable<T> query, QueryFilterRequest queryFilterDto)
        {
            if (!string.IsNullOrEmpty(queryFilterDto.ColumnOrder))
            {
                var queryIQueryable = query.AsQueryable();
                query = OrderByProperty(queryIQueryable, queryFilterDto.ColumnOrder, queryFilterDto.DirectionOrder);
            }

            return query as IOrderedQueryable<T>;
        }

        /// <summary>
        /// Dynamically orders the source queryable by the specified property and direction.
        /// </summary>
        /// <param name="source">The queryable source.</param>
        /// <param name="propertyName">The name of the property to order by.</param>
        /// <param name="direction">The direction to sort ("asc" or "desc").</param>
        /// <returns>The ordered queryable collection.</returns>
        public static IOrderedQueryable<T> OrderByProperty<T>(IQueryable<T> source, string propertyName, string direction)
        {
            var type = typeof(T);
            var property = type.GetProperty(propertyName);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            var resultExp = Expression.Call(
                typeof(Queryable),
                direction == "desc" ? "OrderByDescending" : "OrderBy",
                new[] { type, property.PropertyType },
                source.Expression,
                Expression.Quote(orderByExp)
            );

            return source.Provider.CreateQuery<T>(resultExp) as IOrderedQueryable<T>;
        }
    }
}
