using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    /// <summary>
    /// Implementation of the service to handle the logic for role assignments to users.
    /// </summary>
    public class UserRoleService : BaseModelService<UserRole, UserRoleDTO, UserRoleRequest>, IUserRoleService
    {
        private readonly IUserRoleRepository _userRolRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleService"/> class.
        /// </summary>
        /// <param name="userRolRepository">The repository for managing user-role assignments.</param>
        public UserRoleService(IUserRoleRepository userRolRepository) : base(userRolRepository)
        {
            _userRolRepository = userRolRepository;
        }
    }
}
