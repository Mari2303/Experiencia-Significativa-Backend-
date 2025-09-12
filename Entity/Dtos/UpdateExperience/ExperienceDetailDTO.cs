

using Entity.Dtos.ModelosParametro;

namespace Entity.Dtos.UpdateExperience
{
        public class ExperienceDetailDTO
        {
            public int ExperienceId { get; set; }

            // De Experience
            public string NameExperiences { get; set; } = string.Empty;
            public DateTime Developmenttime { get; set; } 

            // De Institution
            public string Name { get; set; } = string.Empty;
            public string Department { get; set; } = string.Empty;
            public string Municipality { get; set; } = string.Empty;

            // De Person
            public string FullName { get; set; } = string.Empty;
            public string CodeDane { get; set; } = string.Empty;

            // De Criteria (relación con Evaluation → inicialmente vacío)
            public List<CriteriaDTO> Criterias { get; set; } = new();
        }

       

    }

