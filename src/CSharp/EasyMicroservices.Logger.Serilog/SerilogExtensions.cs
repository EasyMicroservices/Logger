using EasyMicroservices.Logger.Options;
using EasyMicroservices.Logger.Serilog.Providers;
using Serilog;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class SerilogExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="loggerConfiguration"></param>
        /// <returns></returns>
        public static LoggerOption UseSerilog(this LoggerOption options, LoggerConfiguration loggerConfiguration)
        {
            options.ThrowIfNull(nameof(options));
            loggerConfiguration.ThrowIfNull(nameof(loggerConfiguration));
            LoggerOptionBuilder.UseLogger(() => new SerilogProvider(loggerConfiguration));
            return options;
        }
    }
}