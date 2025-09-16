using Entity.Dtos.ModuleOperational;
using Entity.Dtos.UpdateExperience;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Service.Interfaces.ModelOperationService
{
    public interface IExperienceService : IBaseModelService<Experience, ExperienceDTO,ExperienceRequest>
    {

        Task<bool> PatchAsync(ExperienceDetailDTO dto);
        Task<ExperienceDetailDTO?> GetDetailByIdAsync(int id);
        Task<Experience> RegisterExperienceAsync(ExperienceRegisterDTO dto);

        Task<IEnumerable<Experience>> GetExperiencesAsync(string role, int userId);
    }
}
