using Entity.Dtos.ModuleOperation.RegisterExperience;
using Entity.Models.ModuleOperation;

namespace Service.Builders
{
    public class ExperienceBuilder
    {
        private readonly Experience _experience;

        public ExperienceBuilder()
        {
            _experience = new Experience
            {
                StateId = 1, 
                CreatedAt = DateTime.UtcNow,
                
            };
        }

        public ExperienceBuilder WithBasicInfo(ExperienceRegisterDTO dto)
        {
            _experience.NameExperiences = dto.NameExperiences;
            _experience.Code = dto.Code;
            _experience.NameFirstLeader = dto.NameFirstLeader;
            _experience.FirstIdentityDocument = dto.FirstIdentityDocument;
            _experience.FirdtEmail = dto.FirdtEmail;
            _experience.FirstPosition = dto.FirstPosition;
            _experience.FirstPhone = dto.FirstPhone;
            _experience.NameSecondLeader = dto.NameSecondLeader;
            _experience.SecondIdentityDocument = dto.SecondIdentityDocument;
            _experience.SecondEmail = dto.SecondEmail;
            _experience.SecondPosition = dto.SecondPosition;
            _experience.SecondPhone = dto.SecondPhone;
            _experience.Developmenttime = dto.Developmenttime;
            _experience.Recognition = dto.Recognition;
            _experience.Socialization = dto.Socialization;
            _experience.CoordinationTransversalProjects = dto.CoordinationTransversalProjects;
            _experience.Population = dto.Population;
            _experience.PedagogicalStrategies = dto.PedagogicalStrategies;
            _experience.Coverage = dto.Coverage;
            _experience.ExperiencesCovidPandemic = dto.ExperiencesCovidPandemic;
            _experience.ThematicLocation = dto.ThematicLocation;
            _experience.UserId = dto.UserId;

            return this;
        }

        public ExperienceBuilder WithInstitution(InstitutionCreateDTO dto)
        {
            _experience.Institution = new Institution
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
            return this;
        }

       public ExperienceBuilder WithDocuments(IEnumerable<DocumentCreateDTO> docs)
        {
            _experience.Documents = docs.Select(d => new Document
            {
                Name = d.Name,
                UrlPdf = d.UrlPdf,
                UrlLink = d.UrlLink,
                State = true,
                CreatedAt = DateTime.UtcNow
            }).ToList();
            return this;
        }
      
        public ExperienceBuilder WithObjectives(IEnumerable<ObjectiveCreateDTO> objectives)
        {
            _experience.Objectives = objectives.Select(o => new Objective
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
            return this;
        }

        public ExperienceBuilder WithThematics(IEnumerable<int> thematicLineIds)
        {
            _experience.ExperienceLineThematics = thematicLineIds.Select(id => new ExperienceLineThematic
            {
                LineThematicId = id,
                State = true,
                CreatedAt = DateTime.UtcNow
            }).ToList();
            return this;
        }

        public ExperienceBuilder WithGrades(IEnumerable<GradeRegisterDTO> grades)
        {
            _experience.ExperienceGrades = grades.Select(g => new ExperienceGrade
            {
                GradeId = g.GradeId,
                Description = g.Description,
                State = true,
                CreatedAt = DateTime.UtcNow
            }).ToList();
            return this;
        }

        public ExperienceBuilder WithPopulations(IEnumerable<int> populationGradeIds)
        {
            _experience.ExperiencePopulations = populationGradeIds.Select(id => new ExperiencePopulation
            {
                PopulationGradeId = id,
                State = true,
                CreatedAt = DateTime.UtcNow
            }).ToList();
            return this;
        }

        public ExperienceBuilder WithHistory(IEnumerable<HistoryExperienceCreateDTO> historyExperiences, int userId, int stateId = 1)
        {
            if (historyExperiences != null)
            {
                _experience.HistoryExperiences = historyExperiences.Select(h => new HistoryExperience
                {
                    Action = h.Action,
                    TableName = h.TableName,
                    UserId = userId,
                    StateId = stateId,
                    CreatedAt = DateTime.UtcNow
                }).ToList();
            }
            return this;
        }

        public Experience Build() => _experience;
    }
}
