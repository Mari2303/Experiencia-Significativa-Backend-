namespace Entity.Requests
{
    public class UserRequest : BaseRequest
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
        /// Hashed password for user authentication
        /// </summary>
        public string Password { get; set; } = string.Empty;
        /// <summary>
        /// /// Foreign key referencing the associated person
        /// </summary>
        public int PersonId { get; set; }
        /// <summary>
        /// Navigation property to the associated user
        /// </summary>
        public string? Person { get; set; } = null!;
    }
}
