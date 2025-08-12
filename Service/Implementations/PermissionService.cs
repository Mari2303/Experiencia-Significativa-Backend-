using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    /// <summary>
    /// Implementation of the service to handle the logic for permissions.
    /// </summary>
    public class PermissionService : BaseModelService<Permission, PermissionDTO, PermissionRequest>, IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionService"/> class.
        /// </summary>
        /// <param name="permissionRepository">The repository used for managing permissions.</param>
        public PermissionService(IPermissionRepository permissionRepository) : base(permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
    }
}
