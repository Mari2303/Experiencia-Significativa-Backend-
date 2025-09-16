using System.Collections.Generic;
using Entity.Dtos;
using Entity.Dtos.ModuleOperational;
using Entity.Dtos.RegisterExperience;
using static Dapper.SqlMapper;

public class ExperienceRegisterDTO 
{
    public string NameExperiences { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;


    // Datos del lider primer campo 
    public string NameFirstLeader {  get; set; } = string.Empty;
    public string FirstIdentityDocument {  get; set; } = string.Empty;
    public string FirdtEmail { get; set; } = string.Empty;
    public string FirstPosition { get; set; } = string.Empty;
    public uint FirstPhone { get; set; }


    // Datos del lider segundo campo 
    public string NameSecondLeader { get; set; } = string.Empty;
    public string SecondIdentityDocument { get; set; } = string.Empty;
    public string SecondEmail { get; set; } = string.Empty;
    public string SecondPosition { get; set; } = string.Empty;
    public uint SecondPhone { get; set; }


    // identificacion de la experiencia significativa 
    // ubicacion tematica 
    public string ThematicLocation { get; set; } = string.Empty;
    // estado
    public int StateId { get; set; }


    // tematica y desarrollo 
    public List<int> ThematicLineIds { get; set; } = new();
    public string CoordinationTransversalProjects { get; set; } = string.Empty;
    public string Population { get; set; } = string.Empty;
    public string PedagogicalStrategies { get; set; } = string.Empty;
    public string Coverage { get; set; } = string.Empty;
    public string ExperiencesCovidPandemic { get; set; } = string.Empty;




    // Grado en el desarrollo de la experiencia
    public List<GradeRegisterDTO> Grades { get; set; } = new();




    // grupo poblacionar 
    public List<int> PopulationGradeIds { get; set; } = new();




    // tiempo de desarrollo 
    public DateTime Developmenttime { get; set; } = DateTime.Now;
    public string Recognition { get; set; } = string.Empty;
    public string Socialization { get; set; } = string.Empty;





    //   public string ThemeExperienceArea { get; set; } = string.Empty;


    public int UserId { get; set; }
    public InstitutionCreateDTO Institution { get; set; } = null!;
    public List<DocumentCreateDTO> Documents { get; set; } = new();
    public List<ObjectiveCreateDTO> Objectives { get; set; } = new();
    public List<HistoryExperienceCreateDTO> HistoryExperiences { get; set; } = new();
}

