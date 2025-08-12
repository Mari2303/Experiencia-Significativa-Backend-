using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Service.Interfaces
{
    /// <summary>
    /// Interface that defines service operations related to associations between roles, forms, and permissions.
    /// </summary>
    public interface IRoleFormPermissionService : IBaseModelService<RoleFormPermission, RoleFormPermissionDTO, RoleFormPermissionRequest>
    {
    }
}
