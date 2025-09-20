using System.ComponentModel.DataAnnotations;
using Entity.Dtos.RegisterExperience;

public class ExperienceRegisterDTO
{
    [Required(ErrorMessage = "El nombre de la experiencia es obligatorio")]
    [MaxLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
    public string NameExperiences { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;

    // Datos del primer líder
    [Required(ErrorMessage = "El nombre del primer líder es obligatorio")]
    [MaxLength(50)]
    public string NameFirstLeader { get; set; } = string.Empty;

    [Required(ErrorMessage = "El documento del primer líder es obligatorio")]
    [MaxLength(10)]
    public string FirstIdentityDocument { get; set; } = string.Empty;

    [Required]
   
    public string FirdtEmail { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string FirstPosition { get; set; } = string.Empty;

    [Required]
   
    public uint FirstPhone { get; set; }

    // Datos del segundo líder (pueden ser opcionales si no siempre se registran)
    [MaxLength(50)]
    public string NameSecondLeader { get; set; } = string.Empty;

    [MaxLength(10)]
    public string SecondIdentityDocument { get; set; } = string.Empty;

  
    public string SecondEmail { get; set; } = string.Empty;

    [MaxLength(50)]
    public string SecondPosition { get; set; } = string.Empty;

    
    public uint SecondPhone { get; set; }


    //  Identificación de la experiencia significativa
    [Required]
    [MaxLength(50)]
    public string ThematicLocation { get; set; } = string.Empty;

    [Required]
    public int StateId { get; set; }

    // Temática y desarrollo
    [Required(ErrorMessage = "Debe seleccionar al menos una línea temática")]
    public List<int> ThematicLineIds { get; set; } = new();

    [MaxLength(10)]
    public string CoordinationTransversalProjects { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Population { get; set; } = string.Empty;

    [MaxLength(50)]
    public string PedagogicalStrategies { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Coverage { get; set; } = string.Empty;

    [MaxLength(50)]
    public string ExperiencesCovidPandemic { get; set; } = string.Empty;

    //  Grados 
    [Required]
    public List<GradeRegisterDTO> Grades { get; set; } = new();


    //  Grupo poblacional
    [Required(ErrorMessage = "Debe seleccionar al menos un grupo poblacional")]
    public List<int> PopulationGradeIds { get; set; } = new();


    //  Tiempo de desarrollo
    [Required(ErrorMessage = "Debe indicar la fecha de desarrollo")]
    public DateTime Developmenttime { get; set; }

    [MaxLength(10)]
    public string Recognition { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Socialization { get; set; } = string.Empty;



    //   public string ThemeExperienceArea { get; set; } = string.Empty;


    public int UserId { get; set; }
    public InstitutionCreateDTO Institution { get; set; } = null!;
    public List<DocumentCreateDTO> Documents { get; set; } = new();
    public List<ObjectiveCreateDTO> Objectives { get; set; } = new();
    public List<HistoryExperienceCreateDTO> HistoryExperiences { get; set; } = new();
}

