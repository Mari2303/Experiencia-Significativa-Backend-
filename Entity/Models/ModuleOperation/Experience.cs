
using System.Reflection.Metadata;


namespace Entity.Models.ModuleOperation
{
    public class Experience : BaseModel
    {
        public string NameExperiences { get; set; } = string.Empty;
        public string Summary {  get; set; } = string.Empty;
        public string Methodologias {  get; set; } = string.Empty;
        public string Tranfer {  get; set; } = string.Empty;
        public virtual Verification? Verification { get; set; } = null;
        public string Code {  get; set; } = string.Empty;
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
        public ICollection<HistoryExperience> historyExperiences { get; set; } = new List<HistoryExperience>();
        public ICollection<Verification> verifications { get; set; } = new List<Verification>();

    } 
}
