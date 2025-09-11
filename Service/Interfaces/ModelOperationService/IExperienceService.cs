using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Service.Interfaces.ModelOperationService
{
    public interface IExperienceService : IBaseModelService<Experience, ExperienceDTO,ExperienceRequest>
    {


        Task<Experience> RegisterExperienceAsync(ExperienceRegisterDTO dto);
    }
}
