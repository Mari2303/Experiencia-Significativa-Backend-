using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Repository.Interfaces
{
    /// <summary>
    /// Interface for operations related to modules.
    /// This interface defines methods for retrieving, adding, deleting, and updating modules in the repository.
    /// </summary>
    public interface IBaseModuleRepository : IBaseModelRepository<Module, ModuleDTO, ModuleRequest>
    {
    }
}
