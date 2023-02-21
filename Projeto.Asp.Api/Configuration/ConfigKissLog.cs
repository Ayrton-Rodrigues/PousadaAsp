using Microsoft.Extensions.DependencyInjection;
using KissLog;
using KissLog.AspNetCore;
using KissLog.Formatters;
using System;
using KissLog.CloudListeners.RequestLogsListener;
using KissLog.CloudListeners.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Projeto.Asp.Api.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using LogLevel = KissLog.LogLevel;

namespace Projeto.Asp.Api.Configuration
{
    public static class ConfigKissLog 
    {
        public static IServiceCollection AddConfigKissLog(this IServiceCollection services)
        {

           
            services.AddLogging(logging =>
            {    
                
                logging.AddKissLog(options =>                {
                    
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
        
        public static IApplicationBuilder AddConfigKissLogBuilder(this IApplicationBuilder builder, IConfiguration configure)
        {


            builder.UseKissLogMiddleware(
                options =>
                {
                    options.Listeners.Add(new RequestLogsApiListener(
                        new Application(
                            configure["KissLog.OrganizationId"],
                            configure["KissLog.ApplicationId"])     //  "94e06fdb-9313-4cf2-9317-d28280a1278c"
                    )
                    {
                        ApiUrl = configure["KissLog.ApiUrl"],
                        Interceptor = new LogLevelInterceptor(LogLevel.Information)
                    });
                  
                }
               
            );
            


            return builder;
        }


        
    }
    public class LogLevelInterceptor : ILogListenerInterceptor
    {
        private readonly LogLevel _minLogLevel;
        public LogLevelInterceptor(LogLevel minLogLevel)
        {
            _minLogLevel = minLogLevel;
        }

        public bool ShouldLog(LogMessage message, ILogListener listener)
        {
            if (message.LogLevel < _minLogLevel)
                return false;

            return true;
        }

        public bool ShouldLog(HttpRequest httpRequest, ILogListener listener)
        {
            return true;
        }

        public bool ShouldLog(FlushLogArgs args, ILogListener listener)
        {
            return true;
        }

        public bool ShouldLog(KissLog.Http.HttpRequest httpRequest, ILogListener listener)
        {
            return true;
        }
    }

}
