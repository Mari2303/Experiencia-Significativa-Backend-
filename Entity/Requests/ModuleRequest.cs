namespace Entity.Requests
{
    public class ModuleRequest : BaseRequest
    {
        /// <summary>
        /// Module's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Module's description
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
