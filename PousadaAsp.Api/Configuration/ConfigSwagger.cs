using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace PousadaAsp.Api.Configuration
{
    public static class ConfigSwagger 
    {
        public static IServiceCollection AddConfigSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API - PousadaAsp",
                    Version = "v1",
                    Description = "Esta API visa atender o projeto Pousada Asp",
                    Contact = new OpenApiContact() { Name = "PousadaAsp Admin", Email = "contato@pousadaAsp.com" },
                    License = new OpenApiLicense() { Name = "ASP", Url = new Uri("https://github.com") }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer token",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new string[] {}
                    }
                });                


            });

            return services;
        }

        public static IApplicationBuilder AddConfigSwagger(this IApplicationBuilder app)
        {


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PousadaAsp - API v1");
            });
            
            return app;
        }
    }
}
