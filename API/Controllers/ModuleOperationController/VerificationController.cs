using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class VerificationController : BaseModelController<Verification, VerificationDTO, VerificationRequest>
    {
        private readonly IVerificationService _verificationService;
        private readonly IMapper _mapper;
        public VerificationController(IBaseModelService<Verification, VerificationDTO, VerificationRequest> baseService, IVerificationService verificationService, IMapper mapper) : base(baseService, mapper)
        {
            _verificationService = verificationService;
            _mapper = mapper;
        }
    }
}
