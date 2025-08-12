using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Service.Interfaces
{
    /// <summary>
    /// Interface that defines service operations related to associations between forms and modules.
    /// </summary>
    public interface IFormModuleService : IBaseModelService<FormModule, FormModuleDTO, FormModuleRequest>
    {
    }
}
