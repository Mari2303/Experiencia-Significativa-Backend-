namespace Entity.Requests
{
    public class FormModuleRequest : BaseRequest
    {
            /// <summary>
            /// Foreign key referencing the form
            /// </summary>
            public int FormId { get; set; }
            /// <summary>
            /// Foreign key referencing the module
            /// </summary>
            public int ModuleId { get; set; }
            /// <summary>
            /// Navigation property to the associated form
            /// </summary>
            public string? Form { get; set; } = null!;

            /// <summary>
            /// Navigation property to the associated module
            /// </summary>
            public string? Module { get; set; } = null!;
    }
}