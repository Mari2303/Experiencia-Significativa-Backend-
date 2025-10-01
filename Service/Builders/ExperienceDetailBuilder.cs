using Entity.Models;
using Entity.Dtos.UpdateExperience;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;

namespace Application.Builders
{
    ///<summary>
    ///clase estática es un tipo de clase que no se puede instanciar
    ///Métodos, propiedades y campos dentro de una clase estática deben declararse como static.
    ///</summary>

    /// <summary>
    /// Clase estática que implementa métodos de extensión para mapear la entidad 
    /// <see cref="Experience"/> a diferentes DTOs de detalle, información básica,
    /// institución, documentos y criterios.
    /// </summary>
    public static class ExperienceInfoBuilder
    {
        /// <summary>
        /// Convierte una entidad <see cref="Experience"/> en un objeto <see cref="ExperienceDetailDTO"/>.
        /// Incluye la información de la experiencia, institución asociada, documentos y criterios evaluados.
        /// </summary>
        /// <param name="experience">La entidad <see cref="Experience"/> a mapear.</param>
        /// <returns>Un objeto <see cref="ExperienceDetailDTO"/> con la información estructurada.</returns>
        public static ExperienceDetailDTO ToDetailDTO(this Experience experience)
        {
            return new ExperienceDetailDTO
            {
                ExperienceId = experience.Id,
                Experience = experience.ToExperienceInfoDTO(),
                Institution = experience.Institution?.ToInstitutionDTO() ?? new InstitutionPatchDTO(),
                Documents = experience.Documents?.ToDocumentDTOs() ?? new List<DocumentInfoDTO>(),
                Criterias = experience.Evaluations.ToCriteriaDTOs()
            };
        }

        /// <summary>
        /// Convierte los datos básicos de la experiencia a un objeto <see cref="ExperienceInfoDTO"/>.
        /// Incluye nombre, tiempo de desarrollo, primer líder y resultado de la última evaluación.
        /// </summary>
        /// <param name="experience">La experiencia a mapear.</param>
        /// <returns>Un objeto <see cref="ExperienceInfoDTO"/>.</returns>
        public static ExperienceInfoDTO ToExperienceInfoDTO(this Experience experience)
        {
            return new ExperienceInfoDTO
            {
                NameExperiences = experience.NameExperiences,
                Developmenttime = experience.Developmenttime,
                NameFirstLeader = experience.NameFirstLeader,

                // Se toma el resultado de la última evaluación si existe, de lo contrario "Naciente".
                EvaluationResult = experience.Evaluations != null && experience.Evaluations.Any()
                    ? experience.Evaluations
                        .OrderByDescending(e => e.CreatedAt)
                        .First()
                        .EvaluationResult
                    : "Naciente"
            };
        }

        /// <summary>
        /// Convierte una entidad <see cref="Institution"/> en un objeto <see cref="InstitutionPatchDTO"/>.
        /// Incluye nombre, departamento, municipio y código DANE.
        /// </summary>
        /// <param name="institution">La institución a mapear.</param>
        /// <returns>Un objeto <see cref="InstitutionPatchDTO"/>.</returns>
        public static InstitutionPatchDTO ToInstitutionDTO(this Institution institution)
        {
            return new InstitutionPatchDTO
            {
                Name = institution.Name ?? string.Empty,
                Department = institution.Departament ?? string.Empty,
                Municipality = institution.Municipality ?? string.Empty,
                CodeDane = institution.CodeDane ?? string.Empty
            };
        }

        /// <summary>
        /// Convierte una colección de documentos en una lista de <see cref="DocumentInfoDTO"/>.
        /// Incluye las URLs de los PDFs y enlaces relacionados.
        /// </summary>
        /// <param name="documents">Colección de documentos asociados a la experiencia.</param>
        /// <returns>Lista de objetos <see cref="DocumentInfoDTO"/>.</returns>
        public static List<DocumentInfoDTO> ToDocumentDTOs(this ICollection<Document> documents)
        {
            return documents.Select(d => new DocumentInfoDTO
            {
                UrlPdf = d.UrlPdf,
                UrlLink = d.UrlLink,
            }).ToList();
        }

        /// <summary>
        /// Convierte la colección de evaluaciones de una experiencia en una lista de criterios únicos.
        /// Toma los nombres de los criterios evaluados en cada evaluación.
        /// </summary>
        /// <param name="evaluations">Colección de evaluaciones asociadas a la experiencia.</param>
        /// <returns>Lista de criterios únicos representados por <see cref="CriteriaNameDTO"/>.</returns>
        public static List<CriteriaNameDTO> ToCriteriaDTOs(this ICollection<Evaluation> evaluations)
        {
            return evaluations
                .SelectMany(ev => ev.EvaluationCriterias) // aplanamos criterios de todas las evaluaciones
                .Where(ec => ec.Criteria != null)         // filtramos criterios válidos
                .Select(ec => new CriteriaNameDTO
                {
                    Name = ec.Criteria!.Name
                })
                .DistinctBy(c => c.Name) // eliminamos duplicados por nombre
                .ToList();
        }
    }
}

