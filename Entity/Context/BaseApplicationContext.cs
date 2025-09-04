using Dapper;
using Entity.Models;
using Entity.Models.ModelosParametros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;

namespace Entity.Context
{
    /// <summary>
    /// DbContext base para reutilizar entidades, configuraciones y métodos comunes
    /// </summary>
    public abstract class BaseApplicationContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        protected BaseApplicationContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

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

            InitialData.Data(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }

        // Métodos Dapper
        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object parameters = null!, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string text, object parameters = null!, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }

        public readonly struct DapperEFCoreCommand : IDisposable
        {
            public CommandDefinition Definition { get; }

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

            public void Dispose() { }
        }

        // DbSets
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
    }

    // DbContext concreto para cada base de datos
    public class ApplicationContextSQL : BaseApplicationContext
    {
        public ApplicationContextSQL(DbContextOptions<ApplicationContextSQL> options, IConfiguration configuration)
            : base(options, configuration) { }
    }

    public class ApplicationContextPostgres : BaseApplicationContext
    {
        public ApplicationContextPostgres(DbContextOptions<ApplicationContextPostgres> options, IConfiguration configuration)
            : base(options, configuration) { }
    }
/*
    public class ApplicationContextMySQL : BaseApplicationContext
    {
        public ApplicationContextMySQL(DbContextOptions<ApplicationContextMySQL> options, IConfiguration configuration)
            : base(options, configuration) { }
    } */
}
