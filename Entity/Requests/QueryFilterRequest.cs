namespace Entity.Requests
{
    /// <summary>
    /// Request used to encapsulate filtering, sorting, and pagination criteria for queries.
    /// </summary>
    public class QueryFilterRequest
    {
        /// <summary>
        /// Gets or sets the number of items to include per page.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Gets or sets the current page number (1-based index).
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the text used for filtering results.
        /// </summary>
        public string? Filter { get; set; }

        /// <summary>
        /// Gets or sets the name of the column on which to apply the text filter.
        /// </summary>
        public string? ColumnFilter { get; set; }

        /// <summary>
        /// Gets or sets the name of the column used for ordering the results.
        /// </summary>
        public string? ColumnOrder { get; set; }

        /// <summary>
        /// Gets or sets the direction of ordering: "asc" for ascending, "desc" for descending.
        /// </summary>
        public string? DirectionOrder { get; set; }

        /// <summary>
        /// Gets or sets an optional foreign key value used to filter related entities.
        /// </summary>
        public int? ForeignKey { get; set; }

        /// <summary>
        /// Gets or sets the name of the foreign key property used for filtering.
        /// </summary>
        public string? NameForeignKey { get; set; }

        /// <summary>
        /// Gets or sets the name of the foreign key property used for filtering.
        /// </summary>
        public bool AplyPagination { get; set; }

        public string? Role { get; set; }
        public int? UserId { get; set; }
            public bool? OnlyActive { get; set; }
    }
}
