using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Asp.Api.PousadaAsp.Data.Context;
using Projeto.Asp.Api.PousadaAsp.Data.Repository;
using Projeto.Asp.Api.PousadaAsp.Domain.Interfaces;
using Projeto.Asp.Api.PousadaAsp.Domain.Interfaces.IService;
using Projeto.Asp.Api.PousadaAsp.Domain.Services;

namespace Projeto.Asp.Api.Configuration
{
    public static class ConfigDependencyInjection
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            //Context
            services.AddScoped<PousadaAspDbContext>();

            //AutoMapper
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ConfigAutoMapper());
            });
            
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Repository
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));

            //Services
            services.AddTransient<UserService>();

            
            return services;
        }
    }
}