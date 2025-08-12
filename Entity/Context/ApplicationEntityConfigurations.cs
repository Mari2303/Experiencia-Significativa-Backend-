using Entity.Models;
using Entity.Models.ModelosParametros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Context
{
    /// <summary>
    /// Configures the entities for the application.
    /// It defines the primary keys for the User, Role, Permission, Form, and Module entities.
    /// </summary>
    public class ApplicationEntityConfigurations :
        IEntityTypeConfiguration<User>,
        IEntityTypeConfiguration<Person>,
        IEntityTypeConfiguration<Role>,
        IEntityTypeConfiguration<Permission>,
        IEntityTypeConfiguration<Form>,
        IEntityTypeConfiguration<Module>,
        IEntityTypeConfiguration<UserRole>,
        IEntityTypeConfiguration<FormModule>,
        IEntityTypeConfiguration<RoleFormPermission>,
         IEntityTypeConfiguration<Criteria>,
         IEntityTypeConfiguration<State>,
         IEntityTypeConfiguration<Grade>,
         IEntityTypeConfiguration<LineThematic>,
         IEntityTypeConfiguration<PopulationGrade>





    {
        /// <summary>
        /// Configures the User entity.
        /// Defines the primary key for the User entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }

        /// <summary>
        /// Configures the User entity.
        /// Defines the primary key for the User entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }
        /// <summary>
        /// Configures the Role entity.
        /// Defines the primary key for the Role entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }




        public void Configure(EntityTypeBuilder<Criteria> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }


        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(s => s.Id); // Primary key

        }



        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }


        public void Configure(EntityTypeBuilder<LineThematic> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }


        public void Configure(EntityTypeBuilder<PopulationGrade> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }



        /// <summary>
        /// Configures the Permission entity.
        /// Defines the primary key for the Permission entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }
        /// <summary>
        /// Configures the Form entity.
        /// Defines the primary key for the Form entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }
        /// <summary>
        /// Configures the Module entity.
        /// Defines the primary key for the Module entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasKey(s => s.Id); // Primary key
        }
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId); //UserId

            builder.HasOne(ur => ur.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.RoleId); //RoleId
        }
        public void Configure(EntityTypeBuilder<FormModule> builder)
        {
            builder.HasOne(fm => fm.Form)
                .WithMany(f => f.FormModules)
                .HasForeignKey(fm => fm.FormId); //FormId

            builder.HasOne(fm => fm.Module)
                .WithMany(f => f.FormModules)
                .HasForeignKey(fm => fm.ModuleId); //ModuleId
        }
        public void Configure(EntityTypeBuilder<RoleFormPermission> builder)
        {
            builder.HasOne(rfp => rfp.Role)
                .WithMany(r => r.RoleFormPermissions)
                .HasForeignKey(rfp => rfp.RoleId); //RoleId

            builder.HasOne(rfp => rfp.Form)
                .WithMany(r => r.RoleFormPermissions)
                .HasForeignKey(rfp => rfp.FormId); //FormId

            builder.HasOne(rfp => rfp.Permission)
                .WithMany(r => r.RoleFormPermissions)
                .HasForeignKey(rfp => rfp.PermissionId); //PermissionId
        }
    }
}