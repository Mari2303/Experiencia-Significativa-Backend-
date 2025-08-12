using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    /// <summary>
    /// Implementation of the service to handle the logic for forms.
    /// </summary>
    public class FormService : BaseModelService<Form, FormDTO, FormRequest>,IFormService
    {
        private readonly IFormRepository _formRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormService"/> class.
        /// </summary>
        /// <param name="formRepository">The repository for managing form data.</param>
        public FormService(IFormRepository formRepository) : base(formRepository)
        {
            _formRepository = formRepository;
        }
    }
}
