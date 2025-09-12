using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModelosParametro;
using Entity.Dtos.ModuleOperational;
using Entity.Dtos.UpdateExperience;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces.IModuleOperationRepository;
using Utilities.Helper;

namespace Repository.Implementations.ModuleOperationRepository
{
    public class ExperienceRepository : BaseModelRepository<Experience, ExperienceDTO, ExperienceRequest>, IExperienceRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<Experience, ExperienceDTO> _helperRepository;

        public ExperienceRepository(ApplicationContext context, IMapper mapper, IHelper<Experience, ExperienceDTO> helperRepository, IConfiguration configuration) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _helperRepository = helperRepository;
            _configuration = configuration;
        }


        public async Task<Experience> AddAsync(Experience experience)
        {
            _context.Experiences.Add(experience);
            await _context.SaveChangesAsync();
            return experience;
        }


        public async Task<Experience?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Experiences
                .Include(e => e.Institution)
                .Include(e => e.User)
                    .ThenInclude(u => u.Person)
                .Include(e => e.Evaluations)
                    .ThenInclude(ev => ev.EvaluationCriterias)
                        .ThenInclude(ec => ec.Criteria)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ExperienceDetailDTO?> GetDetailByIdAsync(int id)
        {
            var experience = await GetByIdWithDetailsAsync(id);
            if (experience == null) return null;

            return new ExperienceDetailDTO
            {
                ExperienceId = experience.Id,
                NameExperiences = experience.NameExperiences,
                Developmenttime = experience.Developmenttime,
                Name = experience.Institution?.Name ?? string.Empty,
                Department = experience.Institution?.Departament ?? string.Empty,
                Municipality = experience.Institution?.Commune ?? string.Empty,
                FullName = experience.User?.Person != null
                    ? $"{experience.User.Person.FirstName} {experience.User.Person.FirstLastName}"
                    : string.Empty,
                CodeDane = experience.User?.Person?.CodeDane ?? string.Empty,
                Criterias = experience.Evaluations
                    .SelectMany(ev => ev.EvaluationCriterias)
                    .Select(ec => new CriteriaDTO
                    {
                        Id = ec.Criteria.Id,
                        Name = ec.Criteria.Name,
                        EvaluationValue = ec.Evaluation.Comments
                    })
                    .DistinctBy(c => c.Id)
                    .ToList()
            };
        }


        public async Task UpdateAsync(Experience experience)
        {
            _context.Experiences.Update(experience);
            await _context.SaveChangesAsync();
        }



        public async Task<Experience?> GetByIdAsync(int id)
        {
            return await _context.Experiences
                .FirstOrDefaultAsync(e => e.Id == id);
        }



        public async Task<IEnumerable<Experience>> GetAllAsync()
        {
            return await _context.Experiences.ToListAsync();
        }



        public async Task<IEnumerable<Experience>> GetByUserIdAsync(int userId)
        {
            return await _context.Experiences
                .Where(e => e.UserId == userId)
                .ToListAsync();
        }


    }
}
