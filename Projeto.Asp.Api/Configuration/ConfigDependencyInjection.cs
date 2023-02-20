using AutoMapper;
using DevIO.Api.Extensions;
using KissLog;
using Microsoft.AspNetCore.Http;
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