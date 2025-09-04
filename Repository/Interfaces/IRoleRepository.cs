using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Repository.Interfaces
{
    /// <summary>
    /// Interface for operations related to roles.
    /// This interface defines methods for retrieving, adding, deleting, and updating roles in the repository.
    /// </summary>
    public interface IRoleRepository : IBaseModelRepository<Role, RoleDTO, RoleRequest>
    {
        Task<Role> GetByNameRol(string roleName);

    }
}
