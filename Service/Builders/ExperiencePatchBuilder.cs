using Entity.Dtos.UpdateExperience;
using Entity.Models.ModuleOperation;

namespace Service.Builders
{
    /// <summary>
    /// Clase estática que contiene métodos de extensión para aplicar cambios parciales (PATCH) 
    /// a la entidad <see cref="Experience"/> a partir de un objeto <see cref="ExperiencePatchDTO"/>.
    /// </summary>
    public static class ExperiencePatchBuilder
    {
        /// <summary>
        /// Aplica los cambios enviados en un <see cref="ExperiencePatchDTO"/> sobre la entidad <see cref="Experience"/>.
        /// Solo actualiza los valores que no son nulos o vacíos.
        /// </summary>
        /// <param name="experience">Entidad <see cref="Experience"/> existente en la base de datos.</param>
        /// <param name="dto">Objeto con los nuevos valores a actualizar parcialmente.</param>
        public static void ApplyPatch(this Experience experience, ExperiencePatchDTO dto)
        {
            if (experience == null || dto == null) return;

       
            if (dto.Experience != null)
            {
                // Nombre de la experiencia
                if (!string.IsNullOrWhiteSpace(dto.Experience.NameExperiences))
                    experience.NameExperiences = dto.Experience.NameExperiences;

                // Tiempo de desarrollo (si es un DateTime válido)
                if (dto.Experience.Developmenttime is DateTime dev)
                    experience.Developmenttime = dev;

                // Nombre del primer líder
                if (!string.IsNullOrWhiteSpace(dto.Experience.NameFirstLeader))
                    experience.NameFirstLeader = dto.Experience.NameFirstLeader;

                // Estado de la experiencia (si no es 0)
                if (dto.Experience.StateId is int state && state != 0)
                    experience.StateId = state;
            }

           
            if (dto.Institution != null && experience.Institution != null)
            {
                // Nombre de la institución
                if (!string.IsNullOrWhiteSpace(dto.Institution.Name))
                    experience.Institution.Name = dto.Institution.Name;

                // Departamento
                if (!string.IsNullOrWhiteSpace(dto.Institution.Department))
                    experience.Institution.Departament = dto.Institution.Department;

                // Municipio
                if (!string.IsNullOrWhiteSpace(dto.Institution.Municipality))
                    experience.Institution.Municipality = dto.Institution.Municipality;

                // Código DANE
                if (!string.IsNullOrWhiteSpace(dto.Institution.CodeDane))
                    experience.Institution.CodeDane = dto.Institution.CodeDane;
            }

          
            if (dto.Criterias != null && experience.Evaluations != null)
            {
                foreach (var criteriaDto in dto.Criterias)
                {
                    // Busca un criterio de evaluación que coincida en ID y que esté activo
                    var evaluationCriteria = experience.Evaluations
                        .SelectMany(ev => ev.EvaluationCriterias ?? new List<EvaluationCriteria>())
                        .FirstOrDefault(ec => ec.Criteria != null
                                              && ec.Criteria.Id == criteriaDto.Id
                                              && ec.Evaluation.State == true);

                    // Si encuentra el criterio y tiene un valor válido, actualiza el comentario
                    if (evaluationCriteria != null && !string.IsNullOrWhiteSpace(criteriaDto.EvaluationValue))
                    {
                        evaluationCriteria.Evaluation.Comments = criteriaDto.EvaluationValue;
                    }
                }
            }
        }
    }
}


