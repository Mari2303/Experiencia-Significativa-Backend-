using Entity.Models;
using Entity.Requests;

namespace Service.Interfaces
{
    /// <summary>
    /// Interface that defines operations related to user authentication.
    /// This interface provides methods for login, password change, and user retrieval using JWT tokens.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Retry a JWT for the correct user and password
        /// </summary>
        /// <param name="username">The username of the user attempting to log in.</param>
        /// <param name="password">The password of the user.</param>
        Task<UserLoginResponseRequest> LoginAsync(string username, string password);

        /// <summary>
        /// A task representing the asynchronous operation.
        /// </summary>
        /// <param name="dto">The data transfer object containing the user ID and new password.</param>
        Task ChangePasswordAsync(ChangePasswordRequest changePassword);

        /// <summary>
        /// Return the user corresponding to the token.
        /// </summary>
        /// <param name="token">The JWT token used to retrieve the user.</param>
        Task<User> GetUserFromTokenAsync(string token);

        /// <summary>
        /// Renews an existing JWT token by creating a new token with the same claims but a new expiration time.
        /// </summary> 
        /// <param name="token">The existing JWT token to renew.</param>
        Task<RenewTokenRequest> RenewTokenAsync(string token);
    }
}
