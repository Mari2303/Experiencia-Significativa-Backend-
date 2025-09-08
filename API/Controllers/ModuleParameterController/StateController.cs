using AutoMapper;
using Entity.Dtos.ModelosParametro;
using Entity.Models.ModelosParametros;
using Entity.Requests.ModulesParamer;
using Service.Interfaces.ModuleParamer;
using Service.Interfaces;

namespace API.Controllers.ModuleParamer
{
    public class StateController : BaseModelController<State, StateDTO, StateRequest>
    {
        private readonly IStateService _stateService;
        private readonly IMapper _mapper;

        public StateController(IBaseModelService<State, StateDTO, StateRequest> baseService, IStateService service, IMapper mapper) : base(baseService, mapper)
        {
            _stateService = service;
            _mapper = mapper;
        }
    }
}
