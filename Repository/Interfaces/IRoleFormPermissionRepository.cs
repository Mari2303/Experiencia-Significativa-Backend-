using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Repository.Interfaces
{
    /// <summary>
    /// Interface for operations related to associations between roles, forms, and permissions.
    /// This interface defines methods for managing the associations between roles, forms, and permissions in the repository.
    /// </summary>
    public interface IRoleFormPermissionRepository : IBaseModelRepository<RoleFormPermission, RoleFormPermissionDTO, RoleFormPermissionRequest>
    {
    }
}
