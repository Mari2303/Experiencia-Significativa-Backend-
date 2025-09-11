using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Interfaces.ModelOperationService;

namespace Service.Implementations.ModelOperationService
{
    public class VerificationService : BaseModelService<Verification, VerificationDTO, VerificationRequest>, IVerificationService
    {
        private readonly IVerificationRepository _verificationRepository;
        public VerificationService(IVerificationRepository verificationRepository) : base(verificationRepository)
        {
            _verificationRepository = verificationRepository;
        }
    }
}
