using Entity.Dtos;
using Entity.Dtos.ModelosParametro;
using Entity.Dtos.ModuleOperational;
using Entity.Models;
using Entity.Models.ModelosParametros;
using Entity.Models.ModuleOperation;
using Entity.Requests;
using Entity.Requests.ModuleOperation;
using Entity.Requests.ModulesParamer;
using Repository.Implementations;
using Repository.Implementations.ModuleOperationRepository;
using Repository.Implementations.ModulePararmer;
using Repository.Interfaces;
using Repository.Interfaces.IModuleOperationRepository;
using Repository.Interfaces.ModuleParamer;
using Service.Implementations;
using Service.Implementations.ModelOperationService;
using Service.Implementations.ModuleParamer;
using Service.Interfaces;
using Service.Interfaces.ModelOperationService;
using Service.Interfaces.ModuleParamer;
using Utilities.Helper;

namespace API
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(IServiceCollection services)
        {
            // Dependency injection for AuthService
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            // Dependency injection for HelperService
            services.AddScoped<IHelperService<BaseModel, BaseDTO>, HelperService<BaseModel, BaseDTO>>();
            services.AddScoped<IHelper<BaseModel, BaseDTO>, Helper<BaseModel, BaseDTO>>();

            // Dependency injection for User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBaseModelService<User, UserDTO, UserRequest>, UserService>();
            services.AddScoped<IHelperService<User, UserDTO>, HelperService<User, UserDTO>>();
            services.AddScoped<IHelper<User, UserDTO>, Helper<User, UserDTO>>();

            // Dependency injection for Person
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IBaseModelService<Person, PersonDTO, PersonRequest>, PersonService>();
            services.AddScoped<IHelperService<Person, PersonDTO>, HelperService<Person, PersonDTO>>();
            services.AddScoped<IHelper<Person, PersonDTO>, Helper<Person, PersonDTO>>();

            // Dependency injection for Role
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IBaseModelService<Role, RoleDTO, RoleRequest>, RoleService>();
            services.AddScoped<IHelperService<Role, RoleDTO>, HelperService<Role, RoleDTO>>();
            services.AddScoped<IHelper<Role, RoleDTO>, Helper<Role, RoleDTO>>();

            // Dependency injection for Form
            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<IFormService, FormService>();
            services.AddScoped<IBaseModelService<Form, FormDTO, FormRequest>, FormService>();
            services.AddScoped<IHelperService<Form, FormDTO>, HelperService<Form, FormDTO>>();
            services.AddScoped<IHelper<Form, FormDTO>, Helper<Form, FormDTO>>();

            // Dependency injection for Module
            services.AddScoped<IBaseModuleRepository, ModuleRepository>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IBaseModelService<Module, ModuleDTO, ModuleRequest>, ModuleService>();
            services.AddScoped<IHelperService<Module, ModuleDTO>, HelperService<Module, ModuleDTO>>();
            services.AddScoped<IHelper<Module, ModuleDTO>, Helper<Module, ModuleDTO>>();

            // Dependency injection for Permission
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IBaseModelService<Permission, PermissionDTO, PermissionRequest>, PermissionService>();
            services.AddScoped<IHelperService<Permission, PermissionDTO>, HelperService<Permission, PermissionDTO>>();
            services.AddScoped<IHelper<Permission, PermissionDTO>, Helper<Permission, PermissionDTO>>();

            // Dependency injection for UserRole
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IBaseModelService<UserRole, UserRoleDTO, UserRoleRequest>, UserRoleService>();
            services.AddScoped<IHelperService<UserRole, UserRoleDTO>, HelperService<UserRole, UserRoleDTO>>();
            services.AddScoped<IHelper<UserRole, UserRoleDTO>, Helper<UserRole, UserRoleDTO>>();


            // Dependency injection for FormModule
            services.AddScoped<IFormModuleRepository, FormModuleRepository>();
            services.AddScoped<IFormModuleService, FormModuleService>();
            services.AddScoped<IBaseModelService<FormModule, FormModuleDTO, FormModuleRequest>, FormModuleService>();
            services.AddScoped<IHelperService<FormModule, FormModuleDTO>, HelperService<FormModule, FormModuleDTO>>();
            services.AddScoped<IHelper<FormModule, FormModuleDTO>, Helper<FormModule, FormModuleDTO>>();

            // Dependency injection for RoleFormPermission
            services.AddScoped<IRoleFormPermissionRepository, RoleFormPermissionRepository>();
            services.AddScoped<IRoleFormPermissionService, RoleFormPermissionService>();
            services.AddScoped<IBaseModelService<RoleFormPermission, RoleFormPermissionDTO, RoleFormPermissionRequest>, RoleFormPermissionService>();
            services.AddScoped<IHelperService<RoleFormPermission, RoleFormPermissionDTO>, HelperService<RoleFormPermission, RoleFormPermissionDTO>>();
            services.AddScoped<IHelper<RoleFormPermission, RoleFormPermissionDTO>, Helper<RoleFormPermission, RoleFormPermissionDTO>>();




            // Dependecy injection for Criteria
            services.AddScoped<ICriteriaRepository, CriteriaRepository>();
            services.AddScoped<ICriteriaService, CriteriaService>();
            services.AddScoped<IBaseModelService<Criteria, CriteriaDTO, CriteriaRequest>, CriteriaService>();
            services.AddScoped<IHelperService<Criteria, CriteriaDTO>, HelperService<Criteria, CriteriaDTO>>();
            services.AddScoped<IHelper<Criteria, CriteriaDTO>, Helper<Criteria, CriteriaDTO>>();


            // Dependecy injection for Grade
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IBaseModelService<Grade, GradeDTO, GradeRequest>, GradeService>();
            services.AddScoped<IHelperService<Grade, GradeDTO>, HelperService<Grade, GradeDTO>>();
            services.AddScoped<IHelper<Grade, GradeDTO>, Helper<Grade, GradeDTO>>();


            // Dependecy injection for State
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<IBaseModelService<State, StateDTO, StateRequest>, StateService>();
            services.AddScoped<IHelperService<State, StateDTO>, HelperService<State, StateDTO>>();
            services.AddScoped<IHelper<State, StateDTO>, Helper<State, StateDTO>>();



            // Dependecy injection for LineThematic
            services.AddScoped<ILineThematicRepository, LineThematicRepository>();
            services.AddScoped<ILineThematicService, LineThematicService>();
            services.AddScoped<IBaseModelService<LineThematic, LineThematicDTO, LineThematicRequest>, LineThematicService>();
            services.AddScoped<IHelperService<LineThematic, LineThematicDTO>, HelperService<LineThematic, LineThematicDTO>>();
            services.AddScoped<IHelper<LineThematic, LineThematicDTO>, Helper<LineThematic, LineThematicDTO>>();


            // Dependecy injection for PopulationGrade
            services.AddScoped<IPopulationGradeRepository, PopulationGradeRepository>();
            services.AddScoped<IPopulationGradeService, PopulationGradeService>();
            services.AddScoped<IBaseModelService<PopulationGrade, PopulationGradeDTO, PopulationGradeRequest>, PopulationGradeService>();
            services.AddScoped<IHelperService<PopulationGrade, PopulationGradeDTO>, HelperService<PopulationGrade, PopulationGradeDTO>>();
            services.AddScoped<IHelper<PopulationGrade, PopulationGradeDTO>, Helper<PopulationGrade, PopulationGradeDTO>>();



            // Dependecy injection for Document
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IBaseModelService<Document, DocumentDTO, DocumentRequest>, DocumentService>();
            services.AddScoped<IHelperService<Document, DocumentDTO>, HelperService<Document, DocumentDTO>>();
            services.AddScoped<IHelper<Document, DocumentDTO>, Helper<Document, DocumentDTO>>();


             // Dependecy injection for Evaluation 
            services.AddScoped<IEvaluationRepository, EvaluationRepository>();
            services.AddScoped<IEvaluationService, EvaluationService>();
            services.AddScoped<IBaseModelService<Evaluation, EvaluationDTO, EvaluationRequest>, EvaluationService>();
            services.AddScoped<IHelperService<Evaluation, EvaluationDTO>, HelperService<Evaluation, EvaluationDTO>>();
            services.AddScoped<IHelper<Evaluation, EvaluationDTO>, Helper<Evaluation, EvaluationDTO>>();


            //   // Dependecy injection for EvaluationCriteria 
            services.AddScoped<IEvaluationCriteriaRepository, EvaluationCriteriaRepository>();
            services.AddScoped<IEvaluationCriteriaService, EvaluationCriteriaService>();
            services.AddScoped<IBaseModelService<EvaluationCriteria, EvaluationCriteriaDTO, EvaluationCriteriaRequest>, EvaluationCriteriaService>();
            services.AddScoped<IHelperService<EvaluationCriteria, EvaluationCriteriaDTO>, HelperService<EvaluationCriteria, EvaluationCriteriaDTO>>();
            services.AddScoped<IHelper<EvaluationCriteria, EvaluationCriteriaDTO>, Helper<EvaluationCriteria, EvaluationCriteriaDTO>>();

            // Dependecy injection for Experience 
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<IBaseModelService<Experience, ExperienceDTO, ExperienceRequest>, ExperienceService>();
            services.AddScoped<IHelperService<Experience, ExperienceDTO>, HelperService<Experience, ExperienceDTO>>();
            services.AddScoped<IHelper<Experience, ExperienceDTO>, Helper<Experience, ExperienceDTO>>();

            // Dependecy injection for ExperienceGrade
            services.AddScoped<IExperienceGradeRepository, ExperienceGradeRepository>();
            services.AddScoped<IExperienceGradeService, ExperienceGradeService>();
            services.AddScoped<IBaseModelService<ExperienceGrade, ExperienceGradeDTO, ExperienceGradeRequest>, ExperienceGradeService>();
            services.AddScoped<IHelperService<ExperienceGrade, ExperienceGradeDTO>, HelperService<ExperienceGrade, ExperienceGradeDTO>>();
            services.AddScoped<IHelper<ExperienceGrade, ExperienceGradeDTO>, Helper<ExperienceGrade, ExperienceGradeDTO>>();

            // Dependecy injection for ExperienceLineThematic
            services.AddScoped<IExperienceLineThematicRepository, ExperienceLineThematicRepository>();
            services.AddScoped<IExperienceLineThematicService, ExperienceLineThematicService>();
            services.AddScoped<IBaseModelService<ExperienceLineThematic, ExperienceLineThematicDTO, ExperienceLineThematicRequest>, ExperienceLineThematicService>();
            services.AddScoped<IHelperService<ExperienceLineThematic, ExperienceLineThematicDTO>, HelperService<ExperienceLineThematic, ExperienceLineThematicDTO>>();
            services.AddScoped<IHelper<ExperienceLineThematic, ExperienceLineThematicDTO>, Helper<ExperienceLineThematic, ExperienceLineThematicDTO>>();

            // Dependecy injection for ExperiencePopulation 
            services.AddScoped<IExperiencePopulationRepository, ExperiencePopulationRepository>();
            services.AddScoped<IExperiencePopulationService, ExperiencePopulationService>();
            services.AddScoped<IBaseModelService<ExperiencePopulation, ExperiencePopulationDTO, ExperiencePopulationRequest>, ExperiencePopulationService>();
            services.AddScoped<IHelperService<ExperiencePopulation, ExperiencePopulationDTO>, HelperService<ExperiencePopulation, ExperiencePopulationDTO>>();
            services.AddScoped<IHelper<ExperiencePopulation, ExperiencePopulationDTO>, Helper<ExperiencePopulation, ExperiencePopulationDTO>>();

            // Dependecy injection for HistoryExperience
            services.AddScoped<IHistoryExperienceRepository, HistoryExperienceRepository>();
            services.AddScoped<IHistoryExperienceService, HistoryExperienceService>();
            services.AddScoped<IBaseModelService<HistoryExperience, HistoryExperienceDTO, HistoryExperienceRequest>, HistoryExperienceService>();
            services.AddScoped<IHelperService<HistoryExperience, HistoryExperienceDTO>, HelperService<HistoryExperience, HistoryExperienceDTO>>();
            services.AddScoped<IHelper<HistoryExperience, HistoryExperienceDTO>, Helper<HistoryExperience, HistoryExperienceDTO>>();

            // Dependecy injection for Institution 
            services.AddScoped<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<IInstitutionService, InstitutionService>();
            services.AddScoped<IBaseModelService<Institution, InstitutionDTO, InstitutionRequest>, InstitutionService>();
            services.AddScoped<IHelperService<Institution, InstitutionDTO>, HelperService<Institution, InstitutionDTO>>();
            services.AddScoped<IHelper<Institution, InstitutionDTO>, Helper<Institution, InstitutionDTO>>();

            // Dependecy injection for Objective 
            services.AddScoped<IObjectiveRepository, ObjectiveRepository>();
            services.AddScoped<IObjectiveService, ObjectiveService>();
            services.AddScoped<IBaseModelService<Objective, ObjectiveDTO, ObjectiveRequest>, ObjectiveService>();
            services.AddScoped<IHelperService<Objective, ObjectiveDTO>, HelperService<Objective, ObjectiveDTO>>();
            services.AddScoped<IHelper<Objective, ObjectiveDTO>, Helper<Objective, ObjectiveDTO>>();

            // Dependecy injection for Verification 
            services.AddScoped<IVerificationRepository, VerificationRepository>();
            services.AddScoped<IVerificationService, VerificationService>();
            services.AddScoped<IBaseModelService<Verification, VerificationDTO, VerificationRequest>, VerificationService>();
            services.AddScoped<IHelperService<Verification, VerificationDTO>, HelperService<Verification, VerificationDTO>>();
            services.AddScoped<IHelper<Verification, VerificationDTO>, Helper<Verification, VerificationDTO>>();




        }
    }
}
