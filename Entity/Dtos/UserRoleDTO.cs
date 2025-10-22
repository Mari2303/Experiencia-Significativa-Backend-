
namespace Entity.Dtos
{
    /// <summary>
    /// Represents the association between a user and a role
    /// </summary>
    public class UserRoleDTO : BaseDTO
    {
        /// <summary>
        /// Foreign key referencing the user
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Foreign key referencing the role
        /// </summary>
        public int RoleId { get; set; }
    }
}
