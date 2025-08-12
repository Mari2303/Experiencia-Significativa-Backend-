using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using Microsoft.OpenApi.Models;

namespace API
{
    public static class AuthenticationExtensions
    {
        public static void CustomSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter just your token"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }
        public static void AddCustomAuthentication(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:Key"]));
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        var response = context.Response;
                        response.ContentType = "application/json";
                        response.StatusCode = StatusCodes.Status401Unauthorized;

                        string message;

                        try
                        {
                            throw context.Exception;
                        }
                        catch (SecurityTokenExpiredException)
                        {
                            message = "Token expired, create a new one";
                        }
                        catch (SecurityTokenInvalidSignatureException)
                        {
                            message = "Invalid token - signature verification failed";
                        }
                        catch (Exception)
                        {
                            message = "Authentication failed";
                        }

                        var json = JsonSerializer.Serialize(new
                        {
                            error = message
                        });

                        return response.WriteAsync(json);
                    }
                };
            });
        }
    }
}
