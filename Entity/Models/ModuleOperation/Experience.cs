
using System.Reflection.Metadata;
using Entity.Models.ModelosParametros;


namespace Entity.Models.ModuleOperation
{
    public class Experience : BaseModel
    {
        public string NameExperiences { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;


        // Datos del lider primer campo 
        public string NameFirstLeader { get; set; } = string.Empty;
        public string FirstIdentityDocument { get; set; } = string.Empty;
        public string FirdtEmail { get; set; } = string.Empty;
        public string FirstPosition { get; set; } = string.Empty;
        public uint FirstPhone { get; set; }


        // Datos del lider segundo campo 
        public string NameSecondLeader { get; set; } = string.Empty;
        public string SecondIdentityDocument { get; set; } = string.Empty;
        public string SecondEmail { get; set; } = string.Empty;
        public string SecondPosition { get; set; } = string.Empty;
        public uint SecondPhone { get; set; }



        // tema experience 

        public string ThematicLocation { get; set; } = string.Empty;

         // tiempo de desarrollo 
        public DateTime Developmenttime { get; set; } = DateTime.Now;
        public string Recognition { get; set; } = string.Empty;
        public string Socialization { get; set; } = string.Empty;



        //  public string ThemeExperienceArea {  get; set; } = string.Empty;
        public string CoordinationTransversalProjects { get; set; } = string.Empty;
        public string Population { get; set; } = string.Empty;
        public string PedagogicalStrategies { get; set; } = string.Empty;
        public string Coverage { get; set; } = string.Empty;
        public string ExperiencesCovidPandemic { get; set; } = string.Empty;






        public int StateId { get; set; }
        public virtual State State { get; set; }
        public virtual Verification? Verification { get; set; } = null;
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public int InstitucionId { get; set; }
        public virtual Institution Institution {  set; get; } = null!;

        public ICollection<Document> Documents { get; set; } = new List<Document>();
        public ICollection<ExperienceLineThematic> ExperienceLineThematics { get; set; } = new List<ExperienceLineThematic>();
        public ICollection<ExperienceGrade> ExperienceGrades { get; set; } = new List<ExperienceGrade>();
        public ICollection<Objective> Objectives { get; set; } = new List<Objective>();
        public ICollection<ExperiencePopulation> ExperiencePopulations { get; set;} = new List<ExperiencePopulation>();
        public ICollection<Evaluation>  Evaluations { get; set; } = new List<Evaluation>();
        public ICollection<HistoryExperience> HistoryExperiences { get; set; } = new List<HistoryExperience>();
        public ICollection<Verification> verifications { get; set; } = new List<Verification>();

    } 
}
