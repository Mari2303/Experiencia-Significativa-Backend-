namespace Entity.Requests
{
    public class UserRoleRequest : BaseRequest
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
        public string? User { get; set; } = null!;
        /// <summary>
        /// Navigation property to the associated role
        /// </summary>
        public string? Role { get; set; } = null!;
    }
}
