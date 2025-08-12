namespace Entity.Models
{
    /// <summary>
    /// Represents the association between a form and a module
    /// </summary>
    public class FormModule : BaseModel
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
        public virtual Form Form { get; set; } = null!;

        /// <summary>
        /// Navigation property to the associated module
        /// </summary>
        public virtual Module Module { get; set; } = null!;
    }
}
