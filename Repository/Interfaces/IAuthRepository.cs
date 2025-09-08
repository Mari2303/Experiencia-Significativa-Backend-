using Entity.Models;
using Entity.Requests;

namespace Repository.Interfaces
{
    public interface IAuthRepository
    {
        /// <summary>
        /// Performs the login of a user, validating their credentials.
        /// </summary>
        /// <param name="username">The username of the user attempting to log in.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A JWT token if the credentials are valid, or an error message if they are not.</returns>
        Task<UserLoginResponseRequest> LoginAsync(string username, string password);

        /// <summary>
        /// Changes the password of a user.
        /// </summary>
        /// <param name="userId">The ID of the user whose password will be changed.</param>
        /// <param name="newPassword">The new password to be assigned to the user.</param>
        /// <returns>An asynchronous task representing the operation.</returns>
        Task ChangePasswordAsync(ChangePasswordRequest changePassword);

        /// <summary>
        /// Retrieves the user from a valid JWT token.
        /// </summary>
        /// <param name="token">A valid JWT token to retrieve the user details.</param>
        /// <returns>The user corresponding to the provided token.</returns>
        Task<User> GetUserFromTokenAsync(string token);

        /// <summary>
        /// Renews an existing JWT token by creating a new token with the same claims but a new expiration time.
        /// </summary>
        /// <param name="token">The existing JWT token to renew.</param>
        Task<RenewTokenRequest> RenewTokenAsync(string token);
    }
}