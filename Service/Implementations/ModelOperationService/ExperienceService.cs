using Entity.Dtos.ModelosParametro;
using Entity.Dtos.ModuleOperational;
using Entity.Dtos.RegisterExperience;
using Entity.Dtos.UpdateExperience;
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
                experience.Institution = BuildInstitution(dto.Institution);
                experience.ExperienceGrades = BuildGrades(dto.Grades);
                experience.ExperiencePopulations = BuildPopulations(dto.PopulationGradeIds);

                // 🚩 Aquí se crea siempre la institución
                experience.Institution = BuildInstitution(dto.Institution);

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

        private const int DefaultStateId = 1;

        private Experience BuildExperience(ExperienceRegisterDTO dto) => new Experience
        {
            NameExperiences = dto.NameExperiences,
            Code = dto.Code,
            NameFirstLeader = dto.NameFirstLeader,
            FirstIdentityDocument = dto.FirstIdentityDocument,
            FirdtEmail = dto.FirdtEmail,
            FirstPosition = dto.FirstPosition,
            FirstPhone = dto.FirstPhone,
            NameSecondLeader = dto.NameSecondLeader,
            SecondIdentityDocument = dto.SecondIdentityDocument,
            SecondEmail = dto.SecondEmail,
            SecondPosition = dto.SecondPosition,
            SecondPhone = dto.SecondPhone,
            Developmenttime = dto.Developmenttime,
            Recognition = dto.Recognition,
            Socialization = dto.Socialization,
            CoordinationTransversalProjects = dto.CoordinationTransversalProjects,
            Population = dto.Population,
            PedagogicalStrategies = dto.PedagogicalStrategies,
            Coverage = dto.Coverage,
            ExperiencesCovidPandemic = dto.ExperiencesCovidPandemic,
            ThematicLocation = dto.ThematicLocation,
            UserId = dto.UserId,
            StateId = DefaultStateId,
            CreatedAt = DateTime.UtcNow
           
        };

       
        private Institution BuildInstitution(InstitutionCreateDTO dto) => new Institution
        {
            Name = dto.Name,
            Address = dto.Address,
            Phone = dto.Phone,
            CodeDane = dto.CodeDane,
            EmailInstitucional = dto.EmailInstitucional,
            Departament = dto.Departament,
            Commune = dto.Commune,
            Municipality = dto.Municipality,
            NameRector = dto.NameRector,
            EZone = dto.EZone,
            Caracteristic = dto.Caracteristic,
            TerritorialEntity = dto.TerritorialEntity,
            TestsKnow = dto.TestsKnow,
            State = true,
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
                Methodologias = o.Methodologias,
                InnovationExperience = o.InnovationExperience,
                ResulsExperience = o.ResulsExperience,
                SustainabilityExperience = o.SustainabilityExperience,
                Tranfer = o.Tranfer,
                Summary = o.Summary,
                MetaphoricalPhrase = o.MetaphoricalPhrase,
                Testimony = o.Testimony,
                FollowEvaluation = o.FollowEvaluation,
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

        private List<ExperienceGrade> BuildGrades(IEnumerable<GradeRegisterDTO> gradeDtos) =>
        gradeDtos.Select(g => new ExperienceGrade
        {
            GradeId = g.GradeId,
            Description = g.Description,
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

        private List<HistoryExperience> BuildHistoryExperiences(IEnumerable<HistoryExperienceCreateDTO> historyExperiences,
                 int userId,
                 int stateId = DefaultStateId)
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



        public async Task<ExperienceDetailDTO?> GetDetailByIdAsync(int id)
        {
            return await _experienceRepository.GetDetailByIdAsync(id);
        }




        public async Task<bool> PatchAsync(ExperienceDetailDTO dto)
        {
            var experience = await _experienceRepository.GetByIdWithDetailsAsync(dto.ExperienceId);
            if (experience == null) return false;

            // 🔹 Solo actualizamos si el campo viene con valor (no null ni vacío)
            if (!string.IsNullOrEmpty(dto.NameExperiences))
                experience.NameExperiences = dto.NameExperiences;

            if (dto.Developmenttime != default)
                experience.Developmenttime = dto.Developmenttime;

            if (!string.IsNullOrEmpty(dto.NameFirstLeader))
                experience.NameFirstLeader = dto.NameFirstLeader;

            if (dto.StateId != 0)
                experience.StateId = dto.StateId;

            // 🔹 Institution
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

            // 🔹 Actualizar criterios solo si vienen en el dto
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
