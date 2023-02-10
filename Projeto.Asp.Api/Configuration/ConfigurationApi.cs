﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Asp.Api.PousadaAsp.Data.Context;

namespace Projeto.Asp.Api.Configuration
{
    public static class ConfigurationApi
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
            
            return services;
        }

        public static IServiceCollection AddConfigurationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PousadaAspDbContext>( options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                ); 
          
    
      
            return services;
        }
    }
}