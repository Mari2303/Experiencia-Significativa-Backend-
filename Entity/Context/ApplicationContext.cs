    using Dapper;
    using Entity.Models;
    using Entity.Models.ModelosParametros;
using Entity.Models.ModuleOperation;
using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.Configuration;
    using System.Data;
    using System.Reflection;
    using System.Reflection.Emit;
using System.Reflection.Metadata;




namespace Entity.Context
{
    /// <summary>
    /// Database context for managing users, roles, forms, permissions, person, customer, and associations.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        /// <param name="options">The options for the context.</param>
        /// <param name="configuration">The configuration object.</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// Configures the model for the database context.
        /// </summary>
        /// <param name="modelBuilder">The model builder for the context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Apply configurations for all entities with a single configuration class.
            var configuration = new ApplicationEntityConfigurations();
            modelBuilder.ApplyConfiguration<User>(configuration);
            modelBuilder.ApplyConfiguration<Person>(configuration);
            modelBuilder.ApplyConfiguration<Role>(configuration);
            modelBuilder.ApplyConfiguration<Permission>(configuration);
            modelBuilder.ApplyConfiguration<Form>(configuration);
            modelBuilder.ApplyConfiguration<Models.Module>(configuration);
            modelBuilder.ApplyConfiguration<UserRole>(configuration);
            modelBuilder.ApplyConfiguration<FormModule>(configuration);
            modelBuilder.ApplyConfiguration<RoleFormPermission>(configuration);
            modelBuilder.ApplyConfiguration<State>(configuration);
            modelBuilder.ApplyConfiguration<Grade>(configuration);
            modelBuilder.ApplyConfiguration<Criteria>(configuration);
            modelBuilder.ApplyConfiguration<LineThematic>(configuration);
            modelBuilder.ApplyConfiguration<PopulationGrade>(configuration);

            modelBuilder.ApplyConfiguration<Models.ModuleOperation.Document>(configuration);
            modelBuilder.ApplyConfiguration<Verification>(configuration);
            modelBuilder.ApplyConfiguration<Evaluation>(configuration);
            modelBuilder.ApplyConfiguration<EvaluationCriteria>(configuration);
            modelBuilder.ApplyConfiguration<Experience>(configuration);
            modelBuilder.ApplyConfiguration<ExperienceGrade>(configuration);
            modelBuilder.ApplyConfiguration<ExperienceLineThematic>(configuration);
            modelBuilder.ApplyConfiguration<ExperiencePopulation>(configuration);
            modelBuilder.ApplyConfiguration<HistoryExperience>(configuration);
            modelBuilder.ApplyConfiguration<Institution>(configuration);
            modelBuilder.ApplyConfiguration<Objective>(configuration);



            modelBuilder.Entity<PasswordRecovery>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Code).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Expiration).IsRequired();
                entity.Property(e => e.Active).IsRequired();
            });

            InitialData.Data(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }




        /// <summary>
        /// Configures the context to allow the logging of sensitive data, useful during debugging to view parameter values in logs.
        /// This should be disabled in production environments to avoid security risks.
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        /// <summary>
        /// Overrides the `SaveChanges` method to include auditing logic before saving changes to the database.
        /// </summary>
        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }

        /// <summary>
        /// Overrides the `SaveChangesAsync` method to include auditing logic before saving changes asynchronously.
        /// </summary>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// Ensures auditing by detecting changes in the entities before performing operations on the database.
        /// </summary>
        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }

        /// <summary>
        /// Executes a SQL query using Dapper and returns a collection of objects of the specified type.
        /// </summary>
        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object parameters = null!, int? timeout = null, CommandType? type = null, string? Role = null, int? UserId = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }

        /// <summary>
        /// Executes a SQL query using Dapper and returns the first object of the specified type, or a default value if not found.
        /// </summary>
        public async Task<T> QueryFirstOrDefaultAsync<T>(string text, object parameters = null!, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }

        /// <summary>
        /// Represents a SQL command to be executed using Dapper and Entity Framework Core, encapsulating details like transaction, timeout, and cancellation token.
        /// </summary>
        public readonly struct DapperEFCoreCommand : IDisposable
        {
            /// <summary>
            /// Initializes the command with the provided details.
            /// </summary>
            /// <param name="context">The database context.</param>
            /// <param name="text">The SQL query text.</param>
            /// <param name="parameters">The parameters for the query.</param>
            /// <param name="timeout">The command timeout.</param>
            /// <param name="type">The type of SQL command.</param>
            /// <param name="ct">The cancellation token.</param>
            public DapperEFCoreCommand(DbContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
            {
                var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
                var commandType = type ?? CommandType.Text;
                var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

                Definition = new CommandDefinition(
                    text,
                    parameters,
                    transaction,
                    commandTimeout,
                    commandType,
                    cancellationToken: ct
                );
            }

            public CommandDefinition Definition { get; }

            /// <summary>
            /// Empty implementation of Dispose since no unmanaged resources are used in this command.
            /// </summary>
            public void Dispose()
            {
                // No additional actions needed to release resources in this case.
            }
        }

        // Definition of entities as DbSet properties for interaction with database tables.
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormModule> FormModules { get; set; }
        public DbSet<RoleFormPermission> RoleFormPermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Models.Module> Modules { get; set; }

        public DbSet<State> State { get; set; }
        public DbSet<Criteria> Criteria { get; set; }

        public DbSet<Grade> Grade { get; set; }
        public DbSet<LineThematic> LineThematics { get; set; }
        public DbSet<PopulationGrade> PopulationGrade { get; set; }


        public DbSet<Models.ModuleOperation.Document> Documents { get; set; }
        public DbSet<Verification> verifications { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<EvaluationCriteria> EvaluationCriterias { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<ExperienceGrade> ExperienceGrades { get; set; }
        public DbSet<ExperienceLineThematic> ExperienceLineThematics { get; set; }
        public DbSet<ExperiencePopulation> ExperiencePopulation { get; set; }
        public DbSet<HistoryExperience> HistoryExperiences { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<PasswordRecovery> PasswordRecoveries { get; set; } = null!;

    }
}
