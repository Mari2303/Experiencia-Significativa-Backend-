using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    /// <summary>
    /// Implementation of the service to handle the logic for role-form permission associations.
    /// </summary>
    public class RoleFormPermissionService : BaseModelService<RoleFormPermission, RoleFormPermissionDTO, RoleFormPermissionRequest>, IRoleFormPermissionService
    {
        private readonly IRoleFormPermissionRepository _roleFormPermissionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleFormPermissionService"/> class.
        /// </summary>
        /// <param name="roleFormPermissionRepository">The repository for managing role-form permission associations.</param>
        public RoleFormPermissionService(IRoleFormPermissionRepository roleFormPermissionRepository) : base(roleFormPermissionRepository)
        {
            _roleFormPermissionRepository = roleFormPermissionRepository;
        }
    }
}
