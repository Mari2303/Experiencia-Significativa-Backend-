using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Repository.Interfaces
{
    /// <summary>
    /// Interface for operations related to the associations between forms and modules.
    /// This interface defines methods for managing the associations between forms and modules in the repository.
    /// </summary>
    public interface IFormModuleRepository : IBaseModelRepository<FormModule, FormModuleDTO, FormModuleRequest>
    {
    }
}
