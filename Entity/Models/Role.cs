namespace Entity.Models
{
    /// <summary>
    /// Represents a security role that can be assigned to users
    /// </summary>
    public class Role : GenericModel
    {
        /// <summary>
        /// Description of the role's purpose and scope
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Collection of user assignments for this role
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        /// <summary>
        /// Collection of permissions assigned to this role for specific forms
        /// </summary>
        public virtual ICollection<RoleFormPermission> RoleFormPermissions { get; set; } = new List<RoleFormPermission>();

     
    }

}
