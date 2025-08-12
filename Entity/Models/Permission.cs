namespace Entity.Models
{
    /// <summary>
    /// Represents a specific permission that can be granted to roles for forms
    /// </summary>
    public class Permission : GenericModel
    {
        /// <summary>
        /// Description of what the permission allows
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Collection of role-form associations where this permission is granted
        /// </summary>
        public virtual ICollection<RoleFormPermission> RoleFormPermissions { get; set; } = new List<RoleFormPermission>();
    }
}
