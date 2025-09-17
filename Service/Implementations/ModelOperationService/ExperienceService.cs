using Entity.Dtos.ModelosParametro;
using Entity.Dtos.ModuleOperational;
using Entity.Dtos.RegisterExperience;
using Entity.Dtos.UpdateExperience;
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
            return await _experienceRepository.GetDetailByIdAsync(id);
        }

        public async Task<bool> PatchAsync(ExperiencePatchDTO dto)
        {
            var experience = await _experienceRepository.GetByIdWithDetailsAsync(dto.ExperienceId);
            if (experience == null) return false;

            // Experience
            if (!string.IsNullOrEmpty(dto.NameExperiences))
                experience.NameExperiences = dto.NameExperiences;

            if (dto.Developmenttime.HasValue)
                experience.Developmenttime = dto.Developmenttime.Value;

            if (!string.IsNullOrEmpty(dto.NameFirstLeader))
                experience.NameFirstLeader = dto.NameFirstLeader;

            if (dto.StateId.HasValue && dto.StateId.Value != 0)
                experience.StateId = dto.StateId.Value;

            // Institution
            if (experience.Institution != null)
            {
                if (!string.IsNullOrEmpty(dto.Name))
                    experience.Institution.Name = dto.Name;

                if (!string.IsNullOrEmpty(dto.Department))
                    experience.Institution.Departament = dto.Department;

                if (!string.IsNullOrEmpty(dto.Municipality))
                    experience.Institution.Commune = dto.Municipality;

                if (!string.IsNullOrEmpty(dto.CodeDane))
                    experience.Institution.CodeDane = dto.CodeDane;
            }

            // Criteria 
            if (dto.Criterias != null && experience.Evaluations != null)
            {
                foreach (var criteriaDto in dto.Criterias)
                {
                    var evaluationCriteria = experience.Evaluations
                        .SelectMany(ev => ev.EvaluationCriterias)
                        .FirstOrDefault(ec => ec.Criteria.Id == criteriaDto.Id && ec.Evaluation.State == true);

                    if (evaluationCriteria != null && !string.IsNullOrEmpty(criteriaDto.EvaluationValue))
                    {
                        evaluationCriteria.Evaluation.Comments = criteriaDto.EvaluationValue;
                    }
                }
            }

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
