namespace Entity.Requests
{
    public class RoleRequest : BaseRequest
    {
        /// <summary>
        /// Unique code identifier for the role 
        /// </summary>
        public string Code { get; set; } = string.Empty;
        /// <summary>
        /// The name of the role
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Description of what the role allows
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
