using Entity.Models;
using Entity.Requests;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Utilities.JwtAuthentication;

namespace Repository.Implementations
{
    /// <summary>
    /// Implementation of the authentication Repository for login, registration, and token validation handling.
    /// </summary>
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IJwtAuthentication _jwtAuthentication;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration service.</param>
        /// <param name="userService">The user service for managing user data.</param>
        /// <param name="jwtAuthenticationRepository">The JWT authentication service for generating and validating tokens.</param>
        public AuthRepository(IConfiguration configuration, IUserRepository userRepository, IJwtAuthentication jwtAuthentication)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _jwtAuthentication = jwtAuthentication;
        }

        /// <summary>
        /// Logs in a user by validating their username and password, then generates a JWT token.
        /// </summary>
        /// <param name="username">The username of the user attempting to log in.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A <see cref="UserLoginResponseRequest"/> containing user details and the JWT token.</returns>
        /// <exception cref="Exception">Throws if username or password is invalid or incorrect.</exception>
        public async Task<UserLoginResponseRequest> LoginAsync(string username, string password)
        {
            var encodePassword = _jwtAuthentication.EncryptMD5(password);
            if (string.IsNullOrEmpty(username))
            {
                throw new Exception("Empty username");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Empty password");
            }

            UserRequest user = await _userRepository.GetByName(username);
            List<string> roles = await _userRepository.GetRolesByUserId(user.Id);

            if (user == null)
            {
                throw new Exception("The user does not exist");
            }

            if (user.Password.ToUpper() != encodePassword.ToUpper())
            {
                throw new Exception("Incorrect password");
            }

            // If the credentials are valid, generate the JWT token
            var token = _jwtAuthentication.Authenticate(username, encodePassword, roles.FirstOrDefault());

            //Give the menus to which the user has access.
            var menu = await _userRepository.GetMenuAsync(user.Id);

            return new UserLoginResponseRequest
            {
                UserId = user.Id,
                UserName = user.Person!,
                Email = user.Username,
                PersonId = user.PersonId,
                Token = token,
                ExpirationDate = DateTime.UtcNow.AddHours(-3),
                Menu = menu,
                Role = roles
            };

        }

        /// <summary>
        /// Changes the password for a user.
        /// </summary>
        /// <param name="dto">The data transfer object containing the user ID and new password.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="Exception">Throws if the user does not exist or if passwords do not match.</exception>
        public async Task ChangePasswordAsync(ChangePasswordRequest dto)
        {
            User user = await _userRepository.GetById(dto.UserId);

            if (user == null)
            {
                throw new Exception("User does not exist");
            }

            if (dto.NewPassword != dto.ConfirmPassword)
            {
                throw new Exception("Passwords do not match");
            }

            user.Password = _jwtAuthentication.EncryptMD5(dto.NewPassword);

            await _userRepository.Update(user);
        }

        /// <summary>
        /// Retrieves a user from a valid JWT token.
        /// </summary>
        /// <param name="token">The JWT token used to retrieve the user.</param>
        /// <returns>The user corresponding to the token.</returns>
        public async Task<User> GetUserFromTokenAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            return await _userRepository.GetById(userId);
        }

        /// <summary>
        /// Renews an existing JWT token by creating a new token with the same claims but a new expiration time.
        /// </summary>
        /// <param name="token">The existing JWT token to renew.</param>
        /// <returns>A new JWT token with the same claims but a new expiration time, or an error message if the renewal fails.</returns>
        public async Task<RenewTokenRequest> RenewTokenAsync(string token)
        {
            var newToken = _jwtAuthentication.RenewToken(token);
            return new RenewTokenRequest
            {
                Token = newToken
            };
        }
    }
}