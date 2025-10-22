namespace Entity.Models
{
    /// <summary>
    /// Represents the association between a user and a role
    /// </summary>
    public class UserRole : BaseModel
    {
        /// <summary>
        /// Foreign key referencing the user
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Foreign key referencing the role
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Navigation property to the associated user
        /// </summary>
        public virtual User User { get; set; } = null!;

        /// <summary>
        /// Navigation property to the associated role
        /// </summary>
        public virtual Role Role { get; set; } = null!;
    }
}
