using EasyMicroservices.Logger.Logary.Providers;
using EasyMicroservices.Logger.Options;
using Logary;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class LogaryExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public static LoggerOption UseLogary(this LoggerOption options, Logger logger)
        {
            options.ThrowIfNull(nameof(options));
            logger.ThrowIfNull(nameof(logger));
            LoggerOptionBuilder.UseLogger(() => new LogaryProvider(logger));
            return options;
        }
    }
}
