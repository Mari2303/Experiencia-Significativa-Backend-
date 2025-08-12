namespace Entity.Requests
{
    /// <summary>
    /// Data Transfer Object for Authentication a user's
    /// </summary>
    public class AuthenticationRequest
    {
        /// <summary>
        /// The unique username for authentication
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// Password for user authentication
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
