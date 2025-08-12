using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Service.Interfaces
{
    /// <summary>
    /// Interface that defines service operations related to roles.
    /// </summary>
    public interface IRoleService : IBaseModelService<Role, RoleDTO, RoleRequest>
    {
    }
}
