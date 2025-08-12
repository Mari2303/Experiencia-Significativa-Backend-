namespace Entity.Models
{
    /// <summary>
    /// Represents a generec entity in the parameter system
    /// </summary>
    public class GenericModel : BaseModel
    {
        /// <summary>
        /// Unique code identifier for the entity 
        /// </summary>
        public string Code { get; set; } = string.Empty;
        /// <summary>
        /// The name of the entity
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
