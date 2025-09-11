using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Repository.Interfaces
{
    /// <summary>
    /// Interface for operations related to users.
    /// This interface defines methods for retrieving, adding, deleting, and updating users in the repository.
    /// </summary>
    public interface IUserRepository : IBaseModelRepository<User, UserDTO, UserRequest>
    {
        /// <summary>
        /// Retrieves a entity by their Name.
        /// </summary>
        /// <param name="name">The Name of the entity.</param>
        /// <returns>A task representing the asynchronous operation, with a <see cref="User"/> result.</returns>
        Task<UserRequest?> GetByName(string name);

        /// <summary>
        /// Retrieves an access menus that have access for the userId
        /// </summary>
        /// <param name="nameId">The userID of the entity to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation, containing the menus that have access.</returns>
        Task<List<MenuRequest>> GetMenuAsync(int userId);


        Task AddAsync(User entity);

        Task<List<string>> GetRolesByUserId(int userId);


    }
}
