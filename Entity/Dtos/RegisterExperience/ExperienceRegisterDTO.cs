using Entity.Dtos;
using Entity.Dtos.ModuleOperational;
using Entity.Dtos.RegisterExperience;

public class ExperienceRegisterDTO 
{
    public string NameExperiences { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Methodologias { get; set; } = string.Empty;
    public string Tranfer { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;


    public DateTime Developmenttime { get; set; } = DateTime.Now;
    public string Recognition { get; set; } = string.Empty;
    public string Socialization { get; set; } = string.Empty;


    public string ThemeExperienceArea { get; set; } = string.Empty;
    public string CoordinationTransversalProjects { get; set; } = string.Empty;
    public string PedagogicalStrategies { get; set; } = string.Empty;
    public string Coverage { get; set; } = string.Empty;
    public string ExperiencesCovidPandemic { get; set; } = string.Empty;


    public int UserId { get; set; }
    public int InstitucionId { get; set; }
    public int StateId { get; set; }

    public List<int> ThematicLineIds { get; set; } = new();
    public List<int> GradeIds { get; set; } = new();
    public List<int> PopulationGradeIds { get; set; } = new();

    public List<DocumentCreateDTO> Documents { get; set; } = new();
    public List<ObjectiveCreateDTO> Objectives { get; set; } = new();
    public List<HistoryExperienceCreateDTO> HistoryExperiences { get; set; } = new();
}

