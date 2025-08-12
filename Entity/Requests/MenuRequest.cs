namespace Entity.Requests
{
    /// <summary>
    /// Rquest for show a menu
    /// </summary>
    public class MenuRequest
    {
        /// <summary>
        /// The reference to form id
        /// </summary>
        public int FormId { get; set; }

        /// <summary>
        /// The name of the form
        /// </summary>
        public string Form { get; set; } = string.Empty;

        /// <summary>
        /// The URL path or route to access the form
        /// </summary>
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// Icon identifier for UI representation
        /// </summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// Display order for the form in UI
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The reference to module id
        /// </summary>
        public int ModuleId { get; set; }

        /// <summary>
        /// The name of the module
        /// </summary>
        public string Module { get; set; } = string.Empty;

    }
}