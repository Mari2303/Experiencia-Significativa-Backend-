using System;
using System.ComponentModel.DataAnnotations;
using Entity.Dtos.ModelosParametro;
using Entity.Dtos.UpdateExperience;

public class ExperiencePatchDTO
{
    [Required(ErrorMessage = "El ID de la experiencia es obligatorio")]
    public int ExperienceId { get; set; }

    [StringLength(150, ErrorMessage = "El nombre de la experiencia no puede superar los 50 caracteres")]
    public string? NameExperiences { get; set; }

    [DataType(DataType.Date)]
    public DateTime? Developmenttime { get; set; }

    [StringLength(100, ErrorMessage = "El nombre del líder no puede superar los 50 caracteres")]
    public string? NameFirstLeader { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "El estado debe ser mayor a 0")]
    public int? StateId { get; set; }

    // Institution
    [StringLength(100, ErrorMessage = "El nombre de la institución no puede superar los 80 caracteres")]
    public string? Name { get; set; }

    [StringLength(80, ErrorMessage = "El departamento no puede superar los 50 caracteres")]
    public string? Department { get; set; }

    [StringLength(80, ErrorMessage = "El municipio no puede superar los 50 caracteres")]
    public string? Municipality { get; set; }

    [StringLength(20, ErrorMessage = "El código DANE no puede superar los 15 caracteres")]
    public string? CodeDane { get; set; }

    public List<CriteriaUpdateDTO>? Criterias { get; set; }
}

