using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    /// <summary>
    /// Implementation of the authentication service for login, registration, and token validation handling.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authrepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="authRepository">The reference to auth Repository.</param>
        public AuthService(IAuthRepository authrepository)
        {
            _authrepository = authrepository;
        }

        /// <summary>
        /// Retry a JWT for the correct user and password
        /// </summary>
        /// <param name="username">The username of the user attempting to log in.</param>
        /// <param name="password">The password of the user.</param>
        public async Task<UserLoginResponseRequest> LoginAsync(string username, string password)
        {
            return await _authrepository.LoginAsync(username, password);
        }

        /// <summary>
        /// A task representing the asynchronous operation.
        /// </summary>
        /// <param name="request">The data transfer object containing the user ID and new password.</param>
        public async Task ChangePasswordAsync(ChangePasswordRequest request)
        {
            await _authrepository.ChangePasswordAsync(request);
        }

        /// <summary>
        /// Return the user corresponding to the token.
        /// </summary>
        /// <param name="token">The JWT token used to retrieve the user.</param>
        public async Task<User> GetUserFromTokenAsync(string token)
        {
            return await _authrepository.GetUserFromTokenAsync(token);
        }

        /// <summary>
        /// Renews an existing JWT token by creating a new token with the same claims but a new expiration time.
        /// </summary> 
        /// <param name="token">The existing JWT token to renew.</param>
        /// <returns>A RenewTokenDTO containing the new token and its expiration details.</returns>
        public async Task<RenewTokenRequest> RenewTokenAsync(string token)
        {
            return await _authrepository.RenewTokenAsync(token);
        }
    }
}
