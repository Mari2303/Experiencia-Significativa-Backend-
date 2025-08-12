using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Service.Interfaces
{
    /// <summary>
    /// Interface for service operations related to modules.
    /// </summary>
    public interface IModuleService : IBaseModelService<Module, ModuleDTO, ModuleRequest>
    {
    }
}
