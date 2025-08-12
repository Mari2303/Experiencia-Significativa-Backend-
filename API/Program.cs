using API;
using Microsoft.EntityFrameworkCore;
using Entity.Context;
using Repository.Interfaces;
using Service.Implementations;
using Service.Interfaces;
using Repository.Implementations;
using System.Text.Json.Serialization;
using Utilities.JwtAuthentication;


var builder = WebApplication.CreateBuilder(args);

// Configuring the database context
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Configuration to avoid cyclic references in JSON serialization.
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Configure Swagger/OpenAPI for API documentation
builder.Services.AddEndpointsApiExplorer();
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

// Configuring the HTTP Request Pipeline
if (app.Environment.IsDevelopment())
{
    // Use Swagger for API documentation in development only
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuring CORS to allow any origin, method, and header
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

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

// Specific CORS configuration
app.UseCors("_myAllowSpecificOrigins");

// Run the application
app.Run();