using System.ComponentModel.DataAnnotations;

namespace Entity.Dtos.RegisterExperience
{
    public class ObjectiveCreateDTO
    {
        [StringLength(100, ErrorMessage = "La description de problema no debe superar los 100 caracteres")]
        public string DescriptionProblem { get; set; } = string.Empty;

        [Required(ErrorMessage = "El objetivo de la experiencia es obligatorio")]
        [StringLength(100, ErrorMessage = "La frase Objectivo no debe superar los 100 caracteres")]
        public string ObjectiveExperience { get; set; } = string.Empty;

        [Required(ErrorMessage = "El enfoque de la experiencia es obligatorio")]
        [StringLength(100, ErrorMessage = "La frase enfoque no debe superar los 100 caracteres")]
        public string EnfoqueExperience { get; set; } = string.Empty;

        [Required(ErrorMessage = "Las metodologías son obligatorias")]
        [StringLength(150, ErrorMessage = "Las metodologías no deben superar los 150 caracteres")]
        public string Methodologias { get; set; } = string.Empty;

        [Required(ErrorMessage = "La innovación de la experiencia es obligatoria")]
        [StringLength(150, ErrorMessage = "La innovación no debe superar los 150 caracteres")]
        public string InnovationExperience { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los resultados de la experiencia son obligatorios")]
        [StringLength(200, ErrorMessage = "Los resultados no deben superar los 200 caracteres")]
        public string ResulsExperience { get; set; } = string.Empty;

        [Required(ErrorMessage = "La sostenibilidad de la experiencia es obligatoria")]
        [StringLength(150, ErrorMessage = "La sostenibilidad no debe superar los 150 caracteres")]
        public string SustainabilityExperience { get; set; } = string.Empty;

        [StringLength(150, ErrorMessage = "La transferencia no debe superar los 150 caracteres")]
        public string Tranfer { get; set; } = string.Empty;

        [StringLength(150, ErrorMessage = "El resumen no debe superar los 150 caracteres")]
        public string Summary { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "La frase metafórica no debe superar los 100 caracteres")]
        public string MetaphoricalPhrase { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "El testimonio no debe superar los 200 caracteres")]
        public string Testimony { get; set; } = string.Empty;

        [StringLength(150, ErrorMessage = "El seguimiento de la evaluación no debe superar los 150 caracteres")]
        public string FollowEvaluation { get; set; } = string.Empty;
    }
}

