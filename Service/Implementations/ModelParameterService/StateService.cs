using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.ModelosParametro;
using Entity.Models.ModelosParametros;
using Entity.Requests.ModulesParamer;
using Repository.Interfaces.ModuleParamer;
using Service.Interfaces.ModuleParamer;

namespace Service.Implementations.ModuleParamer
{
    public class StateService : BaseModelService<State, StateDTO, StateRequest>, IStateService
    {
        private readonly IStateRepository _stateRepository;


        public StateService(IStateRepository stateRepository) : base(stateRepository)
        {
            _stateRepository = stateRepository;
        }
    
    }
}
