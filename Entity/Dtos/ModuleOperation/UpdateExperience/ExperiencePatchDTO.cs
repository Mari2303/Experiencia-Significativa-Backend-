using System;
using System.ComponentModel.DataAnnotations;
using Entity.Dtos.ModelosParametro;
using Entity.Dtos.UpdateExperience;

public class ExperiencePatchDTO
{
    [Required(ErrorMessage = "El ID de la experiencia es obligatorio")]
    public int ExperienceId { get; set; }

    public ExperienceInfoDTO Experience { get; set; } = null!;

    
    public InstitutionPatchDTO Institution { get; set; } = null!;

    public List<CriteriaUpdateDTO>? Criterias { get; set; }
}

