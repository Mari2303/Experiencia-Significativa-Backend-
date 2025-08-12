namespace Entity.Requests
{
    public class RoleFormPermissionRequest : BaseRequest
    {
        /// <summary>
        /// Foreign key referencing the role
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Foreign key referencing the form
        /// </summary>
        public int FormId { get; set; }
        /// <summary>
        /// Foreign key referencing the permission
        /// </summary>
        public int PermissionId { get; set; }
        /// <summary>
        /// Navigation property to the associated role
        /// </summary>
        public string? Role { get; set; } = null!;
        /// <summary>
        /// Navigation property to the associated form
        /// </summary>
        public string? Form { get; set; } = null!;
        /// <summary>
        /// Navigation property to the associated permission
        /// </summary>
        public string? Permission { get; set; } = null!;
    }
}
