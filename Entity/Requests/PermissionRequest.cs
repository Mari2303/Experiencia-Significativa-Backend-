namespace Entity.Requests
{
    public class PermissionRequest : BaseRequest
    {
        /// <summary>
        /// Unique code identifier for the permission 
        /// </summary>
        public string Code { get; set; } = string.Empty;
        /// <summary>
        /// The name of the permission
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Description of what the permission allows
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
