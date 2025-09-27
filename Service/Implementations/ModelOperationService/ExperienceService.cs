using Application.Builders;
using Entity.Dtos.ModuleOperation.RegisterExperience;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Builders;
using Service.Interfaces.ModelOperationService;

namespace Service.Implementations.ModelOperationService
{
    public class ExperienceService : BaseModelService<Experience, ExperienceDTO, ExperienceRequest>, IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
      
        public ExperienceService(IExperienceRepository experienceRepository) : base(experienceRepository)
        {
            _experienceRepository = experienceRepository;
        
        }

 

        public async Task<Experience> RegisterExperienceAsync(ExperienceRegisterDTO dto)
        {
            try
            {
                var experience = new ExperienceBuilder()
                    .WithBasicInfo(dto)
                    .WithInstitution(dto.Institution)
                   .WithDocuments(dto.Documents)
                    .WithObjectives(dto.Objectives)
                    .WithThematics(dto.ThematicLineIds)
                    .WithGrades(dto.Grades)
                    .WithPopulations(dto.PopulationGradeIds)
                    .WithHistory(dto.HistoryExperiences, dto.UserId)
                    .Build();

                await _experienceRepository.AddAsync(experience);
                return experience;
            }
            catch (DbUpdateException dbEx)
            {
                var innerMessage = dbEx.InnerException?.Message ?? dbEx.Message;
                throw new Exception($"Error al registrar la experiencia (DB): {innerMessage}", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error general al registrar la experiencia: {ex.Message}", ex);
            }
        } 


        public async Task<ExperienceDetailDTO?> GetDetailByIdAsync(int id)
        {
            var experience = await _experienceRepository.GetByIdWithDetailsAsync(id);
            return experience?.ToDetailDTO(); 
        }


        public async Task<bool> PatchAsync(ExperiencePatchDTO dto)
        {
            var experience = await _experienceRepository.GetByIdWithDetailsAsync(dto.ExperienceId);
            if (experience == null) return false;

            
            experience.ApplyPatch(dto);

            await _experienceRepository.UpdateAsync(experience);
            return true;
        }


        public async Task<IEnumerable<Experience>> GetExperiencesAsync(string role, int userId)
        {
            if (role == "Profesor")
                return await _experienceRepository.GetByUserIdAsync(userId);

            
            return await _experienceRepository.GetAllAsync();
        }


    }


}
