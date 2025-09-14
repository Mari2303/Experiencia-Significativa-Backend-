using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModelosParametros;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces.IModuleOperationRepository;
using Utilities.Helper;

namespace Repository.Implementations.ModuleOperationRepository
{
    public class EvaluationRepository : BaseModelRepository<Evaluation, EvaluationDTO, EvaluationRequest>, IEvaluationRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<Evaluation, EvaluationDTO> _helperRepository;
        public EvaluationRepository(ApplicationContext context, IMapper mapper, IHelper<Evaluation, EvaluationDTO> helperRepository, IConfiguration configuration) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _helperRepository = helperRepository;
            _configuration = configuration;
        }

        public async Task<Evaluation> AddEvaluationAsync(Evaluation evaluation)
        {
            _context.Evaluations.Add(evaluation);
            await _context.SaveChangesAsync();
            return evaluation;
        }

        public async Task AddEvaluationCriteriaAsync(EvaluationCriteria evalCriteria)
        {
            _context.EvaluationCriterias.Add(evalCriteria);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCriteriaAsync(Criteria criteria)
        {
            _context.Criteria.Update(criteria);
            await _context.SaveChangesAsync();
        }
        public async Task<Criteria?> GetCriteriaByIdAsync(int id)
        {
            return await _context.Criteria
                .FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task<Experience?> GetExperienceWithInstitutionAsync(int experienceId)
        {
            return await _context.Experiences
                .Include(e => e.Institution)
                .Include(e => e.ExperienceLineThematics)
                .FirstOrDefaultAsync(e => e.Id == experienceId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }




    }
}
