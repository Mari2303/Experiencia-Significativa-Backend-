using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity.Context
{
    internal class InitialData
    {
        public static void Data(ModelBuilder modelBuilder)
        {
            DateTime currentDate = DateTime.UtcNow.AddHours(-5);

            // Roles
            var role = new Role()
            {
                Id = 1,
                Code = "01",
                Name = "SUPERADMIN",
                Description = "",
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<Role>().HasData(role);

            // Persons
            var leader = new Person()
            {
                Id = 1,
                DocumentType = 1,
                IdentificationNumber = "1000000000",
                FirstName = "MARIA",
                MiddleName = "ALEJANDRA",
                FirstLastName = "MARIN",
                SecondLastName = "HENRIQUEZ",
                Email = "mariaalejan1080@gmail.com",
                EmailInstitutional = "mariaa_marinh@soy.sena.com",
                CodeDane = "441001004839",
                CreatedAt = currentDate,
                Phone = 3243652328,
                State = true,
            };
            modelBuilder.Entity<Person>().HasData(leader);

            // Users
            var userleader = new User()
            {
                Id = 1,
                Code = "0001",
                Username = "mariaalejan1080@gmail.com",
                PersonId = 1,
                Password = "202CB962AC59075B964B07152D234B70", // 123
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<User>().HasData(userleader);

            // Users - Roles
            var userRolLeader = new UserRole()
            {
                Id = 1,
                UserId = userleader.Id,
                RoleId = role.Id,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<UserRole>().HasData(userRolLeader);

            // Modules
            var moduleSecurity = new Module()
            {
                Id = 1,
                Name = "Security",
                Description = "El módulo de seguridad gestiona autenticación, roles, permisos y acceso a los formularios del sistema.",
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var moduleOperational = new Module()
            {
                Id = 2,
                Name = "Operational",
                Description = "El módulo operativo gestiona los formularios funcionales principales del sistema.",
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<Module>().HasData(moduleSecurity, moduleOperational);

            // Forms
            var formInicio = new Form()
            {
                Id = 1,
                Name = "Inicio",
                Path = "dashboard",
                Description = "Vista principal del sistema.",
                Icon = "fa-solid fa-house",
                Order = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formExperiencia = new Form()
            {
                Id = 2,
                Name = "Experiencia",
                Path = "experiencias",
                Description = "Gestión de experiencias significativas.",
                Icon = "fa-solid fa-star",
                Order = 2,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formEvaluacion = new Form()
            {
                Id = 3,
                Name = "Evaluación",
                Path = "evaluacion",
                Description = "Gestión de evaluaciones.",
                Icon = "fa-solid fa-clipboard-check",
                Order = 3,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formRoles = new Form()
            {
                Id = 4,
                Name = "Roles",
                Path = "security/roles",
                Description = "Gestión de roles del sistema.",
                Icon = "fa-solid fa-users-gear",
                Order = 4,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formUsers = new Form()
            {
                Id = 5,
                Name = "Users",
                Path = "security/users",
                Description = "Gestión de usuarios.",
                Icon = "fa-solid fa-users",
                Order = 5,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formPersons = new Form()
            {
                Id = 6,
                Name = "Persons",
                Path = "security/persons",
                Description = "Gestión de personas.",
                Icon = "fa-solid fa-user",
                Order = 6,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formSeguimiento = new Form()
            {
                Id = 7,
                Name = "Seguimiento",
                Path = "seguimiento",
                Description = "Formulario de seguimiento.",
                Icon = "fa-solid fa-building-user",
                Order = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<Form>().HasData(formInicio, formExperiencia, formEvaluacion, formRoles, formUsers, formPersons, formSeguimiento);

            // Form - Modules
            var formModuleInicio = new FormModule()
            {
                Id = 1,
                FormId = 1, // Inicio
                ModuleId = 1, // Security
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleExperiencia = new FormModule()
            {
                Id = 2,
                FormId = 2, // Experiencia
                ModuleId = 1, // Security
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleEvaluacion = new FormModule()
            {
                Id = 3,
                FormId = 3, // Evaluación
                ModuleId = 1, // Security
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleRoles = new FormModule()
            {
                Id = 4,
                FormId = 4, // Roles
                ModuleId = 1, // Security
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleUsers = new FormModule()
            {
                Id = 5,
                FormId = 5, // Users
                ModuleId = 1, // Security
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModulePersons = new FormModule()
            {
                Id = 6,
                FormId = 6, // Persons
                ModuleId = 1, // Security
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleSeguimiento = new FormModule()
            {
                Id = 7,
                FormId = 7, // Seguimiento
                ModuleId = 2, // Operational
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<FormModule>().HasData(formModuleInicio, formModuleExperiencia, formModuleEvaluacion, formModuleRoles, formModuleUsers, formModulePersons, formModuleSeguimiento);

            // Permission
            var permissionReadWrite = new Permission()
            {
                Id = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                Code = "0001",
                Name = "Reading and writing",
                Description = "Allows the user to query, update, and delete records within the system, granting full access to the management of associated data.",
            };
            var permissionReadOnly = new Permission()
            {
                Id = 2,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                Code = "0002",
                Name = "Reading only",
                Description = "Allows the user to only view records within the system, without permission to perform updates or deletions.",
            };
            modelBuilder.Entity<Permission>().HasData(permissionReadWrite, permissionReadOnly);

            // Roles - Forms - Permissions
            var RoleFormPermissionInicio = new RoleFormPermission()
            {
                Id = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                RoleId = 1,
                FormId = 1,
                PermissionId = 1,
            };
            var RoleFormPermissionExperiencia = new RoleFormPermission()
            {
                Id = 2,
                RoleId = 1,
                FormId = 2,
                PermissionId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var RoleFormPermissionEvaluacion = new RoleFormPermission()
            {
                Id = 3,
                RoleId = 1,
                FormId = 3,
                PermissionId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var RoleFormPermissionRoles = new RoleFormPermission()
            {
                Id = 4,
                RoleId = 1,
                FormId = 4,
                PermissionId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var RoleFormPermissionUsers = new RoleFormPermission()
            {
                Id = 5,
                RoleId = 1,
                FormId = 5,
                PermissionId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var RoleFormPermissionPersons = new RoleFormPermission()
            {
                Id = 6,
                RoleId = 1,
                FormId = 6,
                PermissionId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var RoleFormPermissionSeguimiento = new RoleFormPermission()
            {
                Id = 7,
                RoleId = 1,
                FormId = 7,
                PermissionId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<RoleFormPermission>().HasData(
                RoleFormPermissionInicio,
                RoleFormPermissionExperiencia,
                RoleFormPermissionEvaluacion,
                RoleFormPermissionRoles,
                RoleFormPermissionUsers,
                RoleFormPermissionPersons,
                RoleFormPermissionSeguimiento
            );
        }
    }
}