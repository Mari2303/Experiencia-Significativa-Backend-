using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Utilities.JwtAuthentication
{
    /// <summary>
    /// Implementation of the JWT authentication Repository to generate and validate JWT tokens.
    /// This service is responsible for user authentication via JWT and MD5 password encryption.
    /// </summary>
    public class JwtAuthentication : IJwtAuthentication
    {
        private readonly string _key;

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtAuthentication"/> class.
        /// </summary>
        /// <param name="key">The secret key used to sign the JWT token.</param>
        public JwtAuthentication(string key)
        {
            this._key = key;
        }


        /// <summary>
        /// Authenticates a user by generating a JWT token if the username and password are valid.
        /// </summary>
        /// <param name="user">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A JWT token if the credentials are valid, otherwise null.</returns>
        public string Authenticate(string user, string password)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                return null!;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(this._key);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Encrypts a password using the MD5 hashing algorithm.
        /// </summary>
        /// <param name="password">The password to encrypt.</param>
        /// <returns>The MD5 hash of the password as a hexadecimal string.</returns>
        public string EncryptMD5(string password)
        {
            using (var md5Hash = MD5.Create())
            {
                // Byte array representation of source string
                var sourceBytes = Encoding.UTF8.GetBytes(password);

                // Generate hash value(Byte Array) for input data
                var hashBytes = md5Hash.ComputeHash(sourceBytes);

                // Convert hash byte array to string
                var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                return hash;
            }
        }

        /// <summary>
        /// Renews an existing JWT token by creating a new token with the same claims but a new expiration time.
        /// </summary>
        /// <param name="existingToken">The existing JWT token to renew.</param>
        /// <returns>A new JWT token with the same claims but a new expiration time, or an error message if the renewal fails.</returns>
        public string RenewToken(string existingToken)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(this._key);

            try
            {
                var jwtToken = tokenHandler.ReadJwtToken(existingToken);

                //Get the claims from the existing token
                var claims = jwtToken.Claims;

                // Create a new token with the same claims but a new expiration time
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var newToken = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(newToken);
            }
            catch (Exception ex)
            {
                return $"Failed to renew token: {ex.Message}";
            }
        }
    }
}