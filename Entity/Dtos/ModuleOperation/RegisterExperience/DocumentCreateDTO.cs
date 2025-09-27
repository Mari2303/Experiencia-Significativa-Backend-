
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Entity.Dtos.ModuleOperation.RegisterExperience
{
    public class DocumentCreateDTO
    {
        [Required(ErrorMessage = "El nombre del documento es obligatorio")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "El nombre debe tener entre 5 y 50 caracteres")]
        public string Name { get; set; } = string.Empty;


        [Required(ErrorMessage = "el documento es obligatorio")]
        public string UrlPdf { get; set; } = string.Empty;




        [Url(ErrorMessage = "La URL del enlace no tiene un formato válido")]
        public string UrlLink { get; set; } = string.Empty;


    }
}

