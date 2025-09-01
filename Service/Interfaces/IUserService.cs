using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Service.Interfaces
{
    /// <summary>
    /// Interface that defines service operations related to users.
    /// </summary>
    public interface IUserService : IBaseModelService<User, UserDTO, UserRequest>
    {
        /// <summary>
        /// Retrieves a specific entity by its name identifier.
        /// </summary>
        /// <param name="name">The Name of the entity to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation, containing the entity if found.</returns>
        Task<UserRequest?> GetByName(string name);
        Task<UserRequest> AddAsync(UserRequest request);



    }
}
