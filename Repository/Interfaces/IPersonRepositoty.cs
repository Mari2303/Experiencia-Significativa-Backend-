using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Repository.Interfaces
{
    /// <summary>
    /// Interface for operations related to persons.
    /// </summary>
    public interface IPersonRepository : IBaseModelRepository<Person, PersonDTO, PersonRequest>
    {
    }
}