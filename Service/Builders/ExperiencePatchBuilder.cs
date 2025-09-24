using Entity.Dtos.UpdateExperience;
using Entity.Models.ModuleOperation;

namespace Service.Builders
{
    public static class ExperiencePatchBuilder
    {
        public static void ApplyPatch(this Experience experience, ExperiencePatchDTO dto)
        {
            if (experience == null || dto == null) return;

            
            // Experience 
            if (dto.Experience != null)
            {
                if (!string.IsNullOrWhiteSpace(dto.Experience.NameExperiences))
                    experience.NameExperiences = dto.Experience.NameExperiences;

                if (dto.Experience.Developmenttime is DateTime dev)
                    experience.Developmenttime = dev;

                if (!string.IsNullOrWhiteSpace(dto.Experience.NameFirstLeader))
                    experience.NameFirstLeader = dto.Experience.NameFirstLeader;

      
                if (dto.Experience.StateId is int state && state != 0)
                    experience.StateId = state;


            }

            // Institution 
            if (dto.Institution != null && experience.Institution != null)
            {
                if (!string.IsNullOrWhiteSpace(dto.Institution.Name))
                    experience.Institution.Name = dto.Institution.Name;

                if (!string.IsNullOrWhiteSpace(dto.Institution.Department))
                    experience.Institution.Departament = dto.Institution.Department;

             
                if (!string.IsNullOrWhiteSpace(dto.Institution.Municipality))
                    experience.Institution.Municipality = dto.Institution.Municipality;

                if (!string.IsNullOrWhiteSpace(dto.Institution.CodeDane))
                    experience.Institution.CodeDane = dto.Institution.CodeDane;
            }

           
            // Criteria 
            if (dto.Criterias != null && experience.Evaluations != null)
            {
                foreach (var criteriaDto in dto.Criterias)
                {
                    var evaluationCriteria = experience.Evaluations
                        .SelectMany(ev => ev.EvaluationCriterias ?? new List<EvaluationCriteria>())
                        .FirstOrDefault(ec => ec.Criteria != null && ec.Criteria.Id == criteriaDto.Id && ec.Evaluation.State == true);

                    if (evaluationCriteria != null && !string.IsNullOrWhiteSpace(criteriaDto.EvaluationValue))
                    {
                        evaluationCriteria.Evaluation.Comments = criteriaDto.EvaluationValue;
                    }
                }
            }
        }
    }
}

