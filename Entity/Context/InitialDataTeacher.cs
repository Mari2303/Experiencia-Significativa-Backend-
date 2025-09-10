using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entity.Context
{
    internal class InitialDataTeacher
    {
        public static void Data(ModelBuilder modelBuilder)
        {
            DateTime currentDate = DateTime.UtcNow.AddHours(-5);

            // Módulo Security
            var moduleSecurity = new Module()
            {
                Id = 1,
                Name = "Security",
                Description = "El módulo de seguridad gestiona la autenticación y el acceso.",
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<Module>().HasData(moduleSecurity);

            // Rol Profesor
            var roleTeacher = new Role()
            {
                Id = 2,
                Code = "0002",
                Name = "Profesor",
                Description = "Rol para profesores",
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<Role>().HasData(roleTeacher);

            // Persona Profesor
            var teacherPerson = new Person()
            {
                Id = 2,
                DocumentType = 1,
                IdentificationNumber = "2000000000",
                FirstName = "JUAN",
                MiddleName = "CARLOS",
                FirstLastName = "PEREZ",
                SecondLastName = "GOMEZ",
                Email = "juan.perez@correo.com",
                EmailInstitutional = "juan_perez@soy.sena.com",
                CodeDane = "441001004840",
                CreatedAt = currentDate,
                Phone = 3123456789,
                State = true,
            };
            modelBuilder.Entity<Person>().HasData(teacherPerson);

            // Usuario Profesor
            var teacherUser = new User()
            {
                Id = 2,
                Code = "0002",
                Username = "juan.perez@correo.com",
                PersonId = 2,
                Password = "202CB962AC59075B964B07152D234B70", // 123
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<User>().HasData(teacherUser);

            // Relación Usuario - Rol Profesor
            var userRoleTeacher = new UserRole()
            {
                Id = 2,
                UserId = teacherUser.Id,
                RoleId = roleTeacher.Id,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<UserRole>().HasData(userRoleTeacher);

            // Formularios: Inicio y Experiencia
            var formInicio = new Form()
            {
                Id = 1,
                Name = "Inicio",
                Path = "dashboard",
                Description = "Vista principal para el profesor.",
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
            modelBuilder.Entity<Form>().HasData(formInicio, formExperiencia);

            // Relación Formulario - Módulo
            var formModuleInicio = new FormModule()
            {
                Id = 1,
                FormId = 1,
                ModuleId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var formModuleExperiencia = new FormModule()
            {
                Id = 2,
                FormId = 2,
                ModuleId = 1,
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<FormModule>().HasData(formModuleInicio, formModuleExperiencia);

            // Permisos solo para Inicio (FormId = 1) y Experiencia (FormId = 2)
            var RoleFormPermissionTeacherInicio = new RoleFormPermission()
            {
                Id = 100,
                RoleId = roleTeacher.Id,
                FormId = 1, // Inicio
                PermissionId = 2, // Solo lectura, por ejemplo
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            var RoleFormPermissionTeacherExperiencia = new RoleFormPermission()
            {
                Id = 101,
                RoleId = roleTeacher.Id,
                FormId = 2, // Experiencia
                PermissionId = 2, // Solo lectura, por ejemplo
                State = true,
                CreatedAt = currentDate,
                DeletedAt = null!
            };
            modelBuilder.Entity<RoleFormPermission>().HasData(RoleFormPermissionTeacherInicio, RoleFormPermissionTeacherExperiencia);
        }
    }
}