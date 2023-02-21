using AutoMapper;
using KissLog;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PousadaAsp.Data.Context;
using PousadaAsp.Data.Repository;
using PousadaAsp.Domain.Interfaces;
using PousadaAsp.Domain.Interfaces.IService;
using PousadaAsp.Domain.Services;
using PousadaAsp.Services.Extensions;

namespace PousadaAsp.Api.Configuration
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

            //Services
            services.AddScoped<LoginService>();
            services.AddScoped<IUserService, UserService>();
            
            //AppSettings
            services.AddScoped<JwtSettings>();

            //Logger
            services.AddScoped<IKLogger>((provider) => Logger.Factory.Get());

            //User
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}