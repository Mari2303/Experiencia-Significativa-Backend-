using Utilities.JwtAuthentication;
using Utilities.Mappers;
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


        }
    }
}