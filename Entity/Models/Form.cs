namespace Entity.Models
{
    /// <summary>
    /// Represents a form or page within the application that can have specific permissions
    /// </summary>
    public class Form : BaseModel
    {
        /// <summary>
        /// The name of the entity
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// The URL path or route to access the form
        /// </summary>
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// Description of the form's purpose and functionality
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Icon identifier for UI representation
        /// </summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// Display order for the form in UI
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Collection of module associations for this form
        /// </summary>
        public virtual ICollection<FormModule> FormModules { get; set; } = new List<FormModule>();

        /// <summary>
        /// Collection of role-specific permissions for this form
        /// </summary>
        public virtual ICollection<RoleFormPermission> RoleFormPermissions { get; set; } = new List<RoleFormPermission>();
    }
}