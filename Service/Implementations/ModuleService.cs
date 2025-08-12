using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    /// <summary>
    /// Implementation of the service to manage modules.
    /// </summary>
    public class ModuleService : BaseModelService<Module, ModuleDTO, ModuleRequest>, IModuleService
    {
        private readonly IModuleRepository _moduleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleService"/> class.
        /// </summary>
        /// <param name="moduleRepository">The repository for managing modules.</param>
        public ModuleService(IModuleRepository moduleRepository) : base(moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }
    }
}
