using Entity.Dtos;
using Entity.Models;
using Entity.Requests;

namespace Utilities.Helper
{
    /// <summary>
    /// Defines a contract for repository operations related to validating relationships of a specific entity type.
    /// </summary>
    /// <typeparam name="T">The entity type, inheriting from <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">The Data Transfer Object (DTO) type, inheriting from <see cref="BaseDTO"/>.</typeparam>
    public interface IHelper<T, D>
        where T : BaseModel
        where D : BaseDTO
    {
        /// <summary>
        /// Validates the relationships associated with the entity identified by the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to validate.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains 
        /// <c>true</c> if the relationships are valid; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> ValidateEntityRelationships(int id);
        // <summary>
        /// Generates a consecutive code based on the number of records in the associated model's table.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the generated consecutive code, formatted as a 4-digit string (e.g., "0001", "0002").
        /// </returns>
        Task<string> GenerateConsecutiveCode();
        /// <summary>
        /// Retrieves a list of key-value pairs representing the values of a specified enumeration type.
        /// </summary>
        /// <param name="enumName">The name of the enum defined in the <c>Entity.Models</c> namespace (e.g., "DocumentType").</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a list of <see cref="DataSelectRequest"/> 
        /// objects, where each item includes the numeric value (<c>Id</c>) and its associated description (<c>DisplayText</c>).
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the enum name does not correspond to a valid enum type.</exception>
        Task<List<DataSelectRequest>> GetEnum(string enumName);

        Task<bool> ValidateDataImport(D request);
    }
}
