using Entity.Models.ModuleOperation;

namespace Entity.Models
{
    /// <summary>
    /// Represents a user in the security system
    /// </summary>
    public class User : BaseModel
    {
        /// <summary>
        /// Unique code identifier for the user 
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// The unique username for authentication
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Foreign key referencing the associated Person
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Hashed password for user authentication
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Navigation property to the associated user
        /// </summary>
        public virtual Person Person { get; set; } = null!;

        /// <summary>
        /// Collection of roles assigned to this user
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

        public virtual ICollection<HistoryExperience> HistoryExperiences { get; set; } = new List<HistoryExperience>();
    }
}
