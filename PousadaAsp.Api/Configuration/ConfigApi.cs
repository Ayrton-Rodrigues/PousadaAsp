using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PousadaAsp.Data.Context;

namespace PousadaAsp.Api.Configuration
{
    public static class ConfigApi
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
            
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            
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
