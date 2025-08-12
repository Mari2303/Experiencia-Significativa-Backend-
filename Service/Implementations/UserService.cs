using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Repository.Interfaces;
using Service.Interfaces;

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
        public async Task<UserRequest> GetByName(string name)
        {
            return await _userRepository.GetByName(name);
        }
    }
}
