using API;
using Microsoft.EntityFrameworkCore;
using Entity.Context;
using Repository.Interfaces;
using Repository.Implementations;
using System.Text.Json.Serialization;
using Utilities.JwtAuthentication;
using Service.Implementations;
using Service.Interfaces;
using Utilities.Email;


var builder = WebApplication.CreateBuilder(args);


// SQL Server
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MySQL
/*builder.Services.AddDbContext<ApplicationContextMySQL>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))
    )); */

// PostgreSQL
builder.Services.AddDbContext<ApplicationContextPostgres>(options =>
   options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));


// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Configuration to avoid cyclic references in JSON serialization.
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Configure Swagger/OpenAPI for API documentation
builder.Services.AddEndpointsApiExplorer();
    // Configuración para envío de correos
    builder.Services.AddTransient<Utilities.Email.Interfaces.IEmailService, Utilities.Email.Implements.EmailService>();
AuthenticationExtensions.CustomSwagger(builder.Services);

// Adding custom services from an extension file
ServiceExtensions.AddCustomServices(builder.Services);

// Configuring the JWT Authentication Repository as a Singleton
builder.Services.AddSingleton<IJwtAuthentication, JwtAuthentication>(provider =>
{
    // Get the key directly from the appsettings.json for the JWT
    var key = builder.Configuration.GetSection("JwtConfig")["Key"];
    return new JwtAuthentication(key);
});


// Configuring the JWT Authentication Service as a Singleton
builder.Services.AddSingleton<IJwtAuthenticationService, JwtAuthenticationService>();





// Configuration for authenticating using JWT Bearer tokens
AuthenticationExtensions.AddCustomAuthentication(builder.Services, builder.Configuration);

// Configuring AutoMapper profiles  
MapperExtension.ConfigureAutoMapper(builder.Services);



var app = builder.Build();

//  Aplicar migraciones automáticamente
using (var scope = app.Services.CreateScope())
{
    var sqlServerContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    sqlServerContext.Database.Migrate();

 //   var mySqlContext = scope.ServiceProvider.GetRequiredService<ApplicationContextMySQL>();
  //  mySqlContext.Database.Migrate();

  //  var postgresContext = scope.ServiceProvider.GetRequiredService<ApplicationContextPostgres>();
  //  postgresContext.Database.Migrate();
}


// Configuring the HTTP Request Pipeline
if (app.Environment.IsDevelopment())
{
    // Use Swagger for API documentation in development only
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuring CORS global con la política "AllowAll"
app.UseCors("AllowAll");

// Configuring Swagger in the application
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BACKEND");
});

// HTTPS Redirect
app.UseHttpsRedirection();

// Routing Configuration
app.UseRouting();

// Authorization settings
app.UseAuthentication();
app.UseAuthorization();

// Mapping controllers to routes
app.MapControllers();

// app.UseCors("_myAllowSpecificOrigins");

// Run the application
app.Run();