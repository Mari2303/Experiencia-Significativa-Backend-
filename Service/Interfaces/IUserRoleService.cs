using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Service.Interfaces
{
    /// <summary>
    /// Interface that defines service operations related to the assignment of roles to users.
    /// </summary>
    public interface IUserRoleService : IBaseModelService<UserRole, UserRoleDTO, UserRoleRequest>
    {
    }
}
