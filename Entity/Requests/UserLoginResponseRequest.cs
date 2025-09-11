namespace Entity.Requests
{
    /// <summary>
    /// Request for the response after successful login
    /// </summary>
    public class UserLoginResponseRequest
    {
        /// <summary>
        /// The unique identifier for the authenticated user
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// User's login username
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// User's personId
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// User's email address
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// JWT access token for authenticated API requests
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Expiration date and time for the JWT token
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// List of menu that have access the user
        /// </summary>
        public List<MenuRequest> Menu { get; set; } = new();
        /// <summary>
        /// User's role name
        /// </summary>
        public List<string> Role { get; set; } = new();
    }
}
