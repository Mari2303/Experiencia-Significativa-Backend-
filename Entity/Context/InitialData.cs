using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity.Context
{
    internal class InitialData
    {
        public static void Data(ModelBuilder modelBuilder)
        {
            DateTime currentDate = DateTime.UtcNow.AddHours(-5);

            //Roles
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

            //Persons
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
                EmailInstitutional ="mariaa_marinh@soy.sena.com",
                CodeDane = "441001004839",
                CreatedAt = currentDate,
                Phone = 3243652328,
                State = true,
            };
            modelBuilder.Entity<Person>().HasData(leader);

            //Users
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

            //Users - Roles
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

            //Modules
            var moduleSecurity = new Module()
            {
                Id = 1,
                Name = "Security",
                Description = "The security module manages authentication, roles, permissions, and access to the system's forms and modules, ensuring the control and protection of information.",
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var moduleOperational = new Module()
            {
                Id = 2,
                Name = "Operational",
                Description = "The operational module manages the system's core functional forms, allowing users to execute day-to-day activities",
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<Module>().HasData(moduleSecurity, moduleOperational);

            //Forms
            var formModules = new Form()
            {
                Id = 1,
                Name = "Modules",
                Path = "security/modules",
                Description = "Manages system modules, allowing users to define, modify, and assign modules available to them based on established roles and permissions.",
                Icon = "fa-solid fa-window-maximize",
                Order = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var forms = new Form()
            {
                Id = 2,
                Name = "Forms",
                Path = "security/forms",
                Description = "Manages the forms available in the system, allowing the creation, modification, and deletion of forms associated with different functionalities and modules.",
                Icon = "fa-solid fa-window-restore",
                Order = 2,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formPermissions = new Form()
            {
                Id = 3,
                Name = "Permissions",
                Path = "security/permissions",
                Description = "Allows you to assign specific permissions to users and roles, controlling access to functions, forms, and modules according to the system's needs and security policies.",
                Icon = "fa-solid fa-user-lock",
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
                Description = "Defines and manages roles within the system, allowing you to assign specific permissions to each role and control access to different application features and resources.",
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
                Description = "It allows you to manage user information, including its creation, editing, and deletion. It facilitates the assignment of roles and permissions, ensuring controlled access to the system.",
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
                Description = "It allows you to manage the information of people associated with the system, such as users, employees, or any other relevant entity. It facilitates the creation, editing, and deletion of records, allowing you to link people to specific roles, modules, and permissions as needed.",
                Icon = "fa-solid fa-user",
                Order = 6,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formCustomer = new Form()
            {
                Id = 7,
                Name = "Customers",
                Path = "operational/customers",
                Description = "This form allows the registration and management of customers within the system. It facilitates the creation, editing, and tracking of customer records, enabling the association of relevant operational data and interactions essential for service delivery and follow-up.",
                Icon = "fa-solid fa-building-user",
                Order = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<Form>().HasData(formModules, forms, formPermissions, formRoles, formUsers, formPersons, formCustomer);

            //Form - Modules
            var formModuleModules = new FormModule()
            {
                Id = 1,
                FormId = 1,
                ModuleId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleForms = new FormModule()
            {
                Id = 2,
                FormId = 2,
                ModuleId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModulePermissions = new FormModule()
            {
                Id = 3,
                FormId = 3,
                ModuleId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleRoles = new FormModule()
            {
                Id = 4,
                FormId = 4,
                ModuleId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleUsers = new FormModule()
            {
                Id = 5,
                FormId = 5,
                ModuleId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModulePersons = new FormModule()
            {
                Id = 6,
                FormId = 6,
                ModuleId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleCustomer = new FormModule()
            {
                Id = 7,
                FormId = 7,
                ModuleId = 2,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<FormModule>().HasData(formModuleModules, formModuleForms, formModulePermissions, formModuleRoles, formModuleUsers, formModulePersons, formModuleCustomer);

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
            var RoleFormPermissionModules = new RoleFormPermission()
            {
                Id = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!,
                RoleId = 1,
                FormId = 1,
                PermissionId = 1,
            };
            var RoleFormPermissionForms = new RoleFormPermission()
            {
                Id = 2,
                RoleId = 1,
                FormId = 2,
                PermissionId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var RoleFormPermissionPermissions = new RoleFormPermission()
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
            var RoleFormPermissionCustomer = new RoleFormPermission()
            {
                Id = 7,
                RoleId = 1,
                FormId = 7,
                PermissionId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<RoleFormPermission>().HasData(RoleFormPermissionModules, RoleFormPermissionForms, RoleFormPermissionPermissions, RoleFormPermissionRoles, RoleFormPermissionUsers, RoleFormPermissionPersons, RoleFormPermissionCustomer);
        }
    }
}
