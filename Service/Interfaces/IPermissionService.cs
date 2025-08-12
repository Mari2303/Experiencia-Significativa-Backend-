using Entity.Models;
using Entity.Dtos;
using Entity.Requests;

namespace Service.Interfaces
{
    /// <summary>
    /// Interface that defines service operations related to permissions.
    /// </summary>
    public interface IPermissionService : IBaseModelService<Permission, PermissionDTO, PermissionRequest>
    {
    }
}
