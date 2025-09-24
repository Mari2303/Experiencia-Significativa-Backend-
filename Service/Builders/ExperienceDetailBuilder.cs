using Entity.Models;
using Entity.Dtos.UpdateExperience;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;

namespace Application.Builders
{
    public static class ExperienceInfoBuilder
    {
        // Mapper principal
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

        // datos básicos de experiencia
        public static ExperienceInfoDTO ToExperienceInfoDTO(this Experience experience)
        {
            return new ExperienceInfoDTO
            {
                NameExperiences = experience.NameExperiences,
                Developmenttime = experience.Developmenttime,
                NameFirstLeader = experience.NameFirstLeader,
               
                 // Tomamos la última evaluación si existe, sino "Naciente"
        EvaluationResult = experience.Evaluations != null && experience.Evaluations.Any()
            ? experience.Evaluations
                .OrderByDescending(e => e.CreatedAt)
                .First()
                .EvaluationResult
            : "Naciente"
            };
        }

        //  institución
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

        //  documentos
        public static List<DocumentInfoDTO> ToDocumentDTOs(this ICollection<Document> documents)
        {
            return documents.Select(d => new DocumentInfoDTO
            {
                
                UrlPdf = d.UrlPdf,
                UrlLink = d.UrlLink,
            }).ToList();
        }

        // criterios
        public static List<CriteriaNameDTO> ToCriteriaDTOs(this ICollection<Evaluation> evaluations)
        {
            return evaluations
                .SelectMany(ev => ev.EvaluationCriterias)
                .Where(ec => ec.Criteria != null)
                .Select(ec => new CriteriaNameDTO
                {
                    Name = ec.Criteria!.Name
                })
                .DistinctBy(c => c.Name)
                .ToList();
        }
    }
}

