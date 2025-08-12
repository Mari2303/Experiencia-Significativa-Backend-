using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    /// <summary>
    /// Implementation of the service to handle the logic of associations between forms and modules.
    /// </summary>
    public class FormModuleService : BaseModelService<FormModule, FormModuleDTO, FormModuleRequest>, IFormModuleService
    {
        private readonly IFormModuleRepository _formModuleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormModuleService"/> class.
        /// </summary>
        /// <param name="formModuleRepository">The repository used for managing form-module associations.</param>
        public FormModuleService(IFormModuleRepository formModuleRepository) : base(formModuleRepository)
        {
            _formModuleRepository = formModuleRepository;
        }

    }
}
