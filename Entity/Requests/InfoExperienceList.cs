using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests
{
    public class InfoExperienceListRequest
    {
    public int Id { get; set; }
    public string NameExperiences { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string LeaderName { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Municipality { get; set; } = string.Empty;
    public string DaneCode { get; set; } = string.Empty;
    public string ExperienceType { get; set; } = string.Empty;

    // Si no hay evaluación, este campo puede quedar vacío
    public List<string> EvaluatedCriteria { get; set; } = new();
}
}
