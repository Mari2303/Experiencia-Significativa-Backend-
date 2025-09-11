using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.ModuleOperation;

namespace Entity.Models.ModelosParametros
{
    public class State : BaseModel
    {
        public string Name { get; set; } = string.Empty; 
        public string Code { get; set; } = string.Empty;

        public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
        public virtual ICollection<HistoryExperience> HistoryExperiences { get; set; } = new List<HistoryExperience>();
        public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
    }
}
