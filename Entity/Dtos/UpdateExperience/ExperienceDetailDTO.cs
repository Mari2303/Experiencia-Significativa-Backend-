using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entity.Dtos.UpdateExperience;

public class ExperienceDetailDTO
{
    [Required(ErrorMessage = "El ExperienceId es obligatorio")]
    public int ExperienceId { get; set; }




    // De Experience
    [Required(ErrorMessage = "El nombre de la experiencia es obligatorio")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 150 caracteres")]
    public string NameExperiences { get; set; } = string.Empty;


    [Required(ErrorMessage = "La fecha de desarrollo es obligatoria")]
    [DataType(DataType.Date, ErrorMessage = "Formato de fecha inválido")]
    public DateTime Developmenttime { get; set; }


    [Required(ErrorMessage = "El nombre del líder es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre del líder debe tener entre 3 y 100 caracteres")]
    public string NameFirstLeader { get; set; } = string.Empty;


    [Required(ErrorMessage = "El estado es obligatorio")]
    public int StateId { get; set; }



    // De Institution
    [Required(ErrorMessage = "El nombre de la institución es obligatorio")]
    [StringLength(150, ErrorMessage = "El nombre de la institución no debe superar los 150 caracteres")]
    public string Name { get; set; } = string.Empty;



    [Required(ErrorMessage = "El departamento es obligatorio")]
    [StringLength(100, ErrorMessage = "El departamento no debe superar los 100 caracteres")]
    public string Department { get; set; } = string.Empty;



    [Required(ErrorMessage = "El municipio es obligatorio")]
    [StringLength(100, ErrorMessage = "El municipio no debe superar los 100 caracteres")]
    public string Municipality { get; set; } = string.Empty;

    [Required(ErrorMessage = "El código DANE es obligatorio")]
    [RegularExpression(@"^\d{5,10}$", ErrorMessage = "El código DANE debe ser numérico y tener entre 5 y 10 dígitos")]
    public string CodeDane { get; set; } = string.Empty;




    // Documento de las experiencias
    [Url(ErrorMessage = "La URL del PDF no es válida")]
    public string UrlPdf { get; set; } = string.Empty;

    [Url(ErrorMessage = "La URL del enlace no es válida")]
    public string UrlLink { get; set; } = string.Empty;

    // De Criteria (relación con Evaluation → inicialmente vacío)
    public List<CriteriaNameDTO> Criterias { get; set; } = new();
}


