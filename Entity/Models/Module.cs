namespace Entity.Models
{
    /// <summary>
    /// Represents a module in the security system
    /// </summary>
    public class Module : BaseModel
    {
        /// <summary>
        /// Module's name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Module's description
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Collection of forms assigned to this module
        /// </summary>
        public virtual ICollection<FormModule> FormModules { get; set; } = new List<FormModule>();
    }
}