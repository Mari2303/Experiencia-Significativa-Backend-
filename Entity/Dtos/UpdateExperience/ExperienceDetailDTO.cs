using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entity.Dtos.ModuleOperational;
using Entity.Dtos.UpdateExperience;

public class ExperienceDetailDTO
{
    [Required(ErrorMessage = "El ExperienceId es obligatorio")]
    public int ExperienceId { get; set; }

    public ExperienceInfoDTO Experience { get; set; } = null!;


    public  InstitutionPatchDTO Institution { get; set; } = null!;

    public List<DocumentInfoDTO> Documents { get; set; } = new();

    public List<CriteriaNameDTO> Criterias { get; set; } = new();
}


