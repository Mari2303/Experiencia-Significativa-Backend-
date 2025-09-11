

using System.Text.Json.Serialization;

namespace Entity.Dtos.RegisterExperience
{
    public class DocumentCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string UrlPdf { get; set; } = string.Empty;
        public string UrlLink { get; set; } = string.Empty;
    }
}
