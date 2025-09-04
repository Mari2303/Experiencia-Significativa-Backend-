using System.Security.Cryptography;
using System.Text;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Microsoft.EntityFrameworkCore;
using AutoMapper; 
using Repository.Interfaces;
using Service.Interfaces;
using Repository.Implementations;

namespace Service.Implementations
{
    /// <summary>
    /// Implementation of the service to handle the logic for users.
    /// </summary>
    public class UserService : BaseModelService<User, UserDTO, UserRequest>, IUserService
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The repository for managing user data.</param>
        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Retrieves an entity by its name identifier.
        /// </summary>
        /// <param name="name">The Name of the entity to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, containing the entity if found.</returns>
        //  public async Task<UserRequest> GetByName(string name)
        //  {
        //      return await _userRepository.GetByName(name);
        //   }



        // Obtener usuario por nombre (ya lo tienes)
        public async Task<UserRequest?> GetByName(string name)
        {
            var user = await _userRepository.GetByName(name);
            if (user == null) return null;

            return new UserRequest
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                PersonId = user.PersonId,
                Code = user.Code,
             
            };
        }

        // Sobrescribimos AddAsync para registrar usuarios sin token
        public async Task<UserRequest> AddAsync(UserRequest request)
        {
            // Encriptar password antes de guardar
            string passwordHash = request.Password;
            if (!string.IsNullOrEmpty(request.Password))
            {
                passwordHash = EncryptMD5(request.Password);
            }

            // Mapeo manual de UserRequest -> User (entidad)
            var entity = new User
            {
                Code = request.Code,
                Username = request.Username,
                Password = passwordHash,
                PersonId = request.PersonId,
                State = true,
                CreatedAt = DateTime.UtcNow

            };

            // Guardar en BD
            var savedEntity = await _userRepository.Save(entity);

            // Devolver DTO actualizado
            return new UserRequest
            {
                Id = savedEntity.Id,
                Code = savedEntity.Code,
                Username = savedEntity.Username,
                Password = savedEntity.Password,
                PersonId = savedEntity.PersonId
                 
            };
        }


        private string EncryptMD5(string input)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }
    }

}

