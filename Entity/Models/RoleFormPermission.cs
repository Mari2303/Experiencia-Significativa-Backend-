namespace Entity.Models
{
    /// <summary>
    /// Represents the association between a role, a form, and a specific permission
    /// </summary>
    public class RoleFormPermission : BaseModel
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
        public virtual Role Role { get; set; } = null!;
        /// <summary>
        /// Navigation property to the associated form
        /// </summary>
        public virtual Form Form { get; set; } = null!;
        /// <summary>
        /// Navigation property to the associated permission
        /// </summary>
        public virtual Permission Permission { get; set; } = null!;
    }
}
