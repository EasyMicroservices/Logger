using EasyMicroservices.Logger.Interfaces;
using EasyMicroservices.Logger.Options;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddLogger(this IServiceCollection services, Action<LoggerOption> options)
        {
            return AddLoggerTransient(services, options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddLoggerScoped(this IServiceCollection services, Action<LoggerOption> options)
        {
            options.ThrowIfNull(nameof(options));
            options(new LoggerOption());
            services.AddScoped<ILoggerProvider>(service => LoggerOptionBuilder.GetLogger());
            services.AddScoped<ILoggerProviderAsync>(service => LoggerOptionBuilder.GetLogger());
            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddLoggerTransient(this IServiceCollection services, Action<LoggerOption> options)
        {
            options.ThrowIfNull(nameof(options));
            options(new LoggerOption());
            services.AddTransient<ILoggerProvider>(service => LoggerOptionBuilder.GetLogger());
            services.AddTransient<ILoggerProviderAsync>(service => LoggerOptionBuilder.GetLogger());
            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddLoggerSingleton(this IServiceCollection services, Action<LoggerOption> options)
        {
            options.ThrowIfNull(nameof(options));
            options(new LoggerOption());
            services.AddSingleton<ILoggerProvider>(service => LoggerOptionBuilder.GetLogger());
            services.AddSingleton<ILoggerProviderAsync>(service => LoggerOptionBuilder.GetLogger());
            return services;
        }
    }
}