

namespace Entity.Requests.ModuleOperation
{
    public class ExperienceRequest : BaseRequest
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


        public int UserId { get; set; }
        public string? User { get; set; } = null!;
        public int InstitucionId { get; set; }
        public string? Institution { set; get; } = null!;
        public int StateId { get; set; }
        public string? State { get; set; } = null!;
    }
}
