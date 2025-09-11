using Utilities.JwtAuthentication;
using Utilities.Mappers;
using Utilities.Mappers.ModuleOperation;
using Utilities.Mappers.ModulesParamer;

namespace API
{
    class MapperExtension
    {
        /// <summary>
        /// Configures AutoMapper profiles for the application.
        /// </summary>
        /// <param name="services">The service collection to add the AutoMapper profiles to.</param>
        public static void ConfigureAutoMapper(IServiceCollection services)
        {
            // Create instances of the AutoMapper profiles
            var jwtAuthentication = services.BuildServiceProvider().GetService<IJwtAuthentication>();
            var formProfiles = new FormProfiles();
            var formModuleProfiles = new FormModuleProfiles();
            var moduleProfiles = new ModuleProfiles();
            var permissionProfiles = new PermissionProfiles();
            var personProfiles = new PersonProfiles();
            var roleFormPermissionProfiles = new RoleFormPermissionProfiles();
            var roleProfiles = new RoleProfiles();
            var userProfiles = new UserProfiles(jwtAuthentication);
            var userRoleProfiles = new UserRoleProfiles();
            var criteriaProfiles = new CriteriaProfiles();
            var gradeProfiles = new GradeProfiles();
            var stateProfiles = new StateProfiles();
            var lineThematicProfiles = new LineThematicProfiles();
            var populationGradeProfiles = new PopulationGradeProfiles();

            var documentProfiles = new DocumentProfiles();
            var evaluationProfiles = new EvaluationProfiles();
            var evaluationCriteriaProfiles = new EvaluationCriteriaProfiles();
            var experienceGradeProfiles = new ExperienceGradeProfiles();
            var experienceProfiles = new ExperienceProfiles();
            var experienceLineThematicProfiles = new ExperienceLineThematicProfiles();
            var experiencePopulationProfiles = new ExperiencePopulationProfiles();
            var historyExperienceProfiles = new HistoryExperienceProfiles();
            var objectiveProfiles = new ObjectiveProfiles();
            var verificationProfiles = new VerificationProfiles();
            var InstitutionProfiles = new InstitutionProfiles();



            // Register AutoMapper with the AutoMapperProfiles instance
            services.AddAutoMapper(_ => _.AddProfile(formProfiles));
            services.AddAutoMapper(_ => _.AddProfile(formModuleProfiles));
            services.AddAutoMapper(_ => _.AddProfile(moduleProfiles));
            services.AddAutoMapper(_ => _.AddProfile(permissionProfiles));
            services.AddAutoMapper(_ => _.AddProfile(personProfiles));
            services.AddAutoMapper(_ => _.AddProfile(roleFormPermissionProfiles));
            services.AddAutoMapper(_ => _.AddProfile(roleProfiles));
            services.AddAutoMapper(_ => _.AddProfile(userProfiles));
            services.AddAutoMapper(_ => _.AddProfile(userRoleProfiles));
            services.AddAutoMapper(_=> _.AddProfile(criteriaProfiles));
            services.AddAutoMapper(_=>_.AddProfile(gradeProfiles));
            services.AddAutoMapper(_=>_.AddProfile(stateProfiles));
            services.AddAutoMapper(_ => _.AddProfile(populationGradeProfiles));
            services.AddAutoMapper(_=>_.AddProfile(lineThematicProfiles));

            services.AddAutoMapper(_ => _.AddProfile(documentProfiles));
            services.AddAutoMapper(_ => _.AddProfile(evaluationProfiles));
            services.AddAutoMapper(_ => _.AddProfile(evaluationCriteriaProfiles));
            services.AddAutoMapper(_ => _.AddProfile(experienceGradeProfiles));
            services.AddAutoMapper(_ => _.AddProfile(experienceProfiles));
            services.AddAutoMapper(_ => _.AddProfile(experienceLineThematicProfiles));
            services.AddAutoMapper(_ => _.AddProfile(experiencePopulationProfiles));
            services.AddAutoMapper(_ => _.AddProfile(historyExperienceProfiles));
            services.AddAutoMapper(_ => _.AddProfile(objectiveProfiles));
            services.AddAutoMapper(_ => _.AddProfile(verificationProfiles));
            services.AddAutoMapper(_ => _.AddProfile(InstitutionProfiles));


        }
    }
}