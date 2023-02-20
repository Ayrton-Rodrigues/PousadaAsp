using Microsoft.Extensions.DependencyInjection;
using KissLog;
using KissLog.AspNetCore;
using KissLog.Formatters;
using System;

namespace Projeto.Asp.Api.Configuration
{
    public static class ConfigKissLog 
    {
        public static IServiceCollection AddConfigKissLog(this IServiceCollection services)
        {
            services.AddLogging(logging =>
            {
                logging.AddKissLog(options =>
                {
                    options.Formatter = (FormatterArgs args) =>
                    {
                        if (args.Exception == null)
                            return args.DefaultValue;

                        string exceptionStr = new ExceptionFormatter().Format(args.Exception, args.Logger);

                        return string.Join(Environment.NewLine, new[] { args.DefaultValue, exceptionStr });
                    };
                });
            });
            
            return services;
        }
    }
}
