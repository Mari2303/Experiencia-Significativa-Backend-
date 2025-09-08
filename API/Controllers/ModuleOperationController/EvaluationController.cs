using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class EvaluationController : BaseModelController<Evaluation, EvaluationDTO, EvaluationRequest>
    {
        private readonly IEvaluationService _evaluationService;
        private readonly IMapper _mapper;
        public EvaluationController(IBaseModelService<Evaluation, EvaluationDTO, EvaluationRequest> baseService, IEvaluationService evaluationService, IMapper mapper) : base(baseService, mapper)
        {
            _evaluationService = evaluationService;
            _mapper = mapper;
        }
    }
}
