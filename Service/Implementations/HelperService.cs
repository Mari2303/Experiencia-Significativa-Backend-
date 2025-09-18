using AutoMapper;
using Entity.Dtos;
using Entity.Enums;
using Entity.Models;
using Entity.Requests;
using Repository.Interfaces;
using Utilities.Helper;

namespace Service.Implementations
{
    /// <summary>
    /// Concrete implementation of the abstract helper service that handles entity operations 
    /// and delegates validation logic to the repository layer.
    /// </summary>
    /// <typeparam name="T">The entity type, inheriting from <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">The Data Transfer Object (DTO) type, inheriting from <see cref="BaseDTO"/>.</typeparam>
    public class HelperService<T, D> : AHelperService<T, D>
        where T : BaseModel
        where D : BaseDTO
    {
        private readonly IHelper<T, D> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="HelperService{T, D}"/> class.
        /// </summary>
        /// <param name="repository">The repository instance responsible for data access and relationship validation.</param>
        /// <param name="mapper">The mapper instance used to convert between entities and DTOs.</param>
        public HelperService(IHelper<T, D> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Validates the relationships of the specified entity by delegating to the repository.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to validate.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains 
        /// <c>true</c> if the relationships are valid; otherwise, <c>false</c>.
        /// </returns>
        public override async Task<bool> ValidateEntityRelationships(int id)
        {
            return await _repository.ValidateEntityRelationships(id);
        }
        /// <summary>
        /// Generates a consecutive code by delegating the logic to the repository layer.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the generated 
        /// consecutive code as a 4-digit string (e.g., "0001", "0002").
        /// </returns>
        public override async Task<string> GenerateConsecutiveCode()
        {
            return await _repository.GenerateConsecutiveCode();
        }
        /// <summary>
        /// Retrieves a list of key-value pairs representing the values of the specified enum.
        /// It uses reflection to locate the enum by name in the <c>Entity.Models</c> namespace and extracts its numeric value and associated <see cref="DescriptionAttribute"/>.
        /// </summary>
        /// <param name="enumName">The name of the enum to retrieve, such as "DocumentType" or "Gender".</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is a list of <see cref="DataSelectRequest"/> containing the enum's value (as <c>Id</c>) and its description (as <c>DisplayText</c>).
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if the enum type is not found or is not a valid enumeration.</exception>
        public override async Task<List<DataSelectRequest>> GetEnum(string enumName)
        {
            return await _repository.GetEnum(enumName);
        }

      
    }


}

