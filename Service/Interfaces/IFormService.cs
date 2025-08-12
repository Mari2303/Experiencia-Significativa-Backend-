using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Service.Interfaces
{
    /// <summary>
    /// Interface that defines service operations related to forms.
    /// </summary>
    public interface IFormService : IBaseModelService<Form, FormDTO, FormRequest>
    {
    }
}
