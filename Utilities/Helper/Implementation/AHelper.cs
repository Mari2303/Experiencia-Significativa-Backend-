using Entity.Dtos;
using Entity.Requests;
using Entity.Models;

namespace Utilities.Helper
{
    /// <summary>
    /// Abstract base class for helper repositories that provides a contract for validating entity relationships.
    /// Implements the <see cref="IHelper{T, D}"/> interface.
    /// </summary>
    /// <typeparam name="T">The entity type, inheriting from <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">The Data Transfer Object (DTO) type, inheriting from <see cref="BaseDTO"/>.</typeparam>
    public abstract class AHelper<T, D> : IHelper<T, D>
        where T : BaseModel
        where D : BaseDTO
    {
        /// <summary>
        /// When implemented in a derived class, validates the relationships of the entity identified by the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to validate.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains 
        /// <c>true</c> if the relationships are valid; otherwise, <c>false</c>.
        /// </returns>
        public abstract Task<bool> ValidateEntityRelationships(int id);
        /// <summary>
        /// When implemented in a derived class, generates a consecutive code based on the number of records in the associated model's table.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The result contains the generated consecutive code, formatted as a 4-digit string (e.g., "0001", "0002").
        /// </returns>
        public abstract Task<string> GenerateConsecutiveCode();
        /// <summary>
        /// When implemented in a derived class, retrieves the key-value representation of the specified enumeration.
        /// The method returns a list of <see cref="DataSelectRequest"/>, where each item contains the numeric value (Id) and its corresponding description (DisplayText).
        /// </summary>
        /// <param name="enumName">The name of the enumeration defined in the <c>Entity.Models</c> namespace.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a list of key-value pairs representing the enum values and their descriptions.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the provided <paramref name="enumName"/> does not correspond to a valid enum.</exception>
        public abstract Task<List<DataSelectRequest>> GetEnum(string enumName);

        public abstract Task<bool> ValidateDataImport(D request);
    }
}
