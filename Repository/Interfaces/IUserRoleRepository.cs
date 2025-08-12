using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Repository.Interfaces
{
    /// <summary>
    /// Interface for operations related to role assignments to users.
    /// This interface defines methods for retrieving, adding, deleting, and updating user-role assignments in the repository.
    /// </summary>
    public interface IUserRoleRepository : IBaseModelRepository<UserRole, UserRoleDTO, UserRoleRequest>
    {
    }
}
