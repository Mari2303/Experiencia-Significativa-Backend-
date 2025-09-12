namespace Utilities.JwtAuthentication
{
    /// <summary>
    /// Interface that defines operations for JWT authentication and password encryption.
    /// </summary>
    public interface IJwtAuthentication
    {
        /// <summary>
        /// Authenticates a user based on their username and password.
        /// </summary>
        /// <param name="user">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A JWT token if the authentication is successful.</returns>
        string Authenticate(string user, string password, string role, int userId);

        /// <summary>
        /// Encrypts a password using the MD5 algorithm.
        /// </summary>
        /// <param name="password">The password to be encrypted.</param>
        /// <returns>The MD5 hash of the password.</returns>
        string EncryptMD5(string password);

        /// <summary>
        /// Renews an existing JWT token by creating a new token with the same claims but a new expiration time.
        /// </summary>
        /// <param name="existingToken">The existing JWT token to renew.</param>
        /// <returns>A new JWT token with the same claims but a new expiration time, or an error message if the renewal fails.</returns>
        public string RenewToken(string existingToken);
    }
}