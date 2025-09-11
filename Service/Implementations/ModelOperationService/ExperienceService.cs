using Entity.Dtos.ModuleOperational;
using Entity.Dtos.RegisterExperience;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.IModuleOperationRepository;
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
                var experience = BuildExperience(dto);

                experience.Documents = BuildDocuments(dto.Documents);
                experience.Objectives = BuildObjectives(dto.Objectives);
                experience.HistoryExperiences = BuildHistoryExperiences(dto.HistoryExperiences, dto.UserId);
                experience.ExperienceLineThematics = BuildThematics(dto.ThematicLineIds);
                experience.ExperienceGrades = BuildGrades(dto.GradeIds);
                experience.ExperiencePopulations = BuildPopulations(dto.PopulationGradeIds);



                await _experienceRepository.AddAsync(experience);

                return experience;
            }
            catch (DbUpdateException dbEx)
            {
                // Captura errores relacionados con la base de datos (FK, UNIQUE, NOT NULL, etc.)
                var innerMessage = dbEx.InnerException?.Message ?? dbEx.Message;
                throw new Exception($"Error al registrar la experiencia (DB): {innerMessage}", dbEx);
            }
            catch (Exception ex)
            {
                // Captura errores generales
                throw new Exception($"Error general al registrar la experiencia: {ex.Message}", ex);
            }
        }

        private const int DefaultStateId = 1;


        private Experience BuildExperience(ExperienceRegisterDTO dto) => new Experience
        {
            NameExperiences = dto.NameExperiences,
            Summary = dto.Summary,
            Methodologias = dto.Methodologias,
            Tranfer = dto.Tranfer,
            Code = dto.Code,
            Developmenttime = dto.Developmenttime,
            Recognition = dto.Recognition,
            Socialization = dto.Socialization,
            ThemeExperienceArea = dto.ThemeExperienceArea,
            CoordinationTransversalProjects = dto.CoordinationTransversalProjects,
            PedagogicalStrategies = dto.PedagogicalStrategies,
            Coverage = dto.Coverage,
            ExperiencesCovidPandemic = dto.ExperiencesCovidPandemic,
            UserId = dto.UserId,
            InstitucionId = dto.InstitucionId,
            StateId = DefaultStateId,
            CreatedAt = DateTime.UtcNow
        };

        private List<Document> BuildDocuments(IEnumerable<DocumentCreateDTO> docs) =>
            docs.Select(d => new Document
            {
                Name = d.Name,
                UrlPdf = d.UrlPdf,
                UrlLink = d.UrlLink,
                State = true,
                CreatedAt = DateTime.UtcNow
            }).ToList();

        private List<Objective> BuildObjectives(IEnumerable<ObjectiveCreateDTO> objectives) =>
            objectives.Select(o => new Objective
            {
                DescriptionProblem = o.DescriptionProblem,
                ObjectiveExperience = o.ObjectiveExperience,
                EnfoqueExperience = o.EnfoqueExperience,
                InnovationExperience = o.InnovationExperience,
                ResulsExperience = o.ResulsExperience,
                SustainabilityExperience = o.SustainabilityExperience,
                MetaphoricalPhrase = o.MetaphoricalPhrase,
                Testimony = o.Testimony,
                Dissemination = o.Dissemination,
                State = true,
                CreatedAt = DateTime.UtcNow
            }).ToList();

        private List<ExperienceLineThematic> BuildThematics(IEnumerable<int> thematicLineIds) =>
        thematicLineIds.Select(id => new ExperienceLineThematic
       {
         LineThematicId = id,
            State = true,
         CreatedAt = DateTime.UtcNow
         }).ToList();

        private List<ExperienceGrade> BuildGrades(IEnumerable<int> gradeIds) =>
            gradeIds.Select(id => new ExperienceGrade
            {
                GradeId = id,
                State = true,
                CreatedAt = DateTime.UtcNow
            }).ToList();

        private List<ExperiencePopulation> BuildPopulations(IEnumerable<int> populationGradeIds) =>
            populationGradeIds.Select(id => new ExperiencePopulation
            {
                PopulationGradeId = id,
                State = true,
                CreatedAt = DateTime.UtcNow
            }).ToList();

     private List<HistoryExperience> BuildHistoryExperiences( IEnumerable<HistoryExperienceCreateDTO> historyExperiences,
                  int userId,
                  int stateId = DefaultStateId) // opcional, usa DefaultStateId si no se pasa
        {
            if (historyExperiences == null)
                return new List<HistoryExperience>();

            return historyExperiences.Select(h => new HistoryExperience
            {
                Action = h.Action,
                TableName = h.TableName,
                UserId = userId,
                StateId = stateId,
                CreatedAt = DateTime.UtcNow
            }).ToList();
        }























    }


}
