using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Service.Interfaces
{
    /// <summary>
    /// Interface that defines service operations related to Person.
    /// </summary>
    public interface IPersonService : IBaseModelService<Person, PersonDTO, PersonRequest>
    {
    }
}