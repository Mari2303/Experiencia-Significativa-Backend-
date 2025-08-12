using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Repository.Interfaces
{
    /// <summary>
    /// Interface for operations related to permissions.
    /// This interface defines methods for retrieving, adding, deleting, and updating permissions in the repository.
    /// </summary>
    public interface IPermissionRepository : IBaseModelRepository<Permission, PermissionDTO, PermissionRequest>
    {
    }
}
