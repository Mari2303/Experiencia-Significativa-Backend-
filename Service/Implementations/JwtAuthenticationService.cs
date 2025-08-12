using Service.Interfaces;
using Repository.Interfaces;
using Utilities.JwtAuthentication;

namespace Service.Implementations
{
    /// <summary>
    /// Implementation of the JWT authentication service to generate and validate JWT tokens.
    /// </summary>
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly IJwtAuthentication _jwtAuthentication;

        /// <summary>
        /// Constructor of JwtAuthenticationService
        /// </summary>
        public JwtAuthenticationService(IJwtAuthentication jwtAuthentication)
        {
            _jwtAuthentication = jwtAuthentication;
            _jwtAuthentication = jwtAuthentication;
        }

        /// <summary>
        /// A JWT token if the credentials are valid, otherwise null.
        /// </summary>
        /// <param name="user">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        public string Authenticate(string user, string password)
        {
            return _jwtAuthentication.Authenticate(user, password);
        }

        /// <summary>
        /// The MD5 hash of the password as a hexadecimal string
        /// </summary>
        /// <param name="password">The password to encrypt.</param>
        public string EncryptMD5(string password)
        {
            return _jwtAuthentication.EncryptMD5(password);
        }

        /// <summary>
        /// Renews an existing JWT token by creating a new token with the same claims but a new expiration time.
        /// </summary>
        /// <param name="existingToken">The existing JWT token to renew.</param>
        /// <returns>A new JWT token with the same claims but a new expiration time, or an error message if the renewal fails.</returns>
        public string RenewToken(string existingToken)
        {
            return _jwtAuthentication.RenewToken(existingToken);
        }
    }
}
