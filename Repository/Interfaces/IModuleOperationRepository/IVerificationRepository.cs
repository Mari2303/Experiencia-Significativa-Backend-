using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Repository.Interfaces.IModuleOperationRepository
{
    public interface IVerificationRepository : IBaseModelRepository<Verification, VerificationDTO, VerificationRequest>
    {
    }
}
