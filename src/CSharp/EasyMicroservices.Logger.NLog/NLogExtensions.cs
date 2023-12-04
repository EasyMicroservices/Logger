using EasyMicroservices.Logger.NLog.Providers;
using EasyMicroservices.Logger.Options;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class NLogExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public static LoggerOption UseNLog(this LoggerOption options, NLog.Logger logger)
        {
            options.ThrowIfNull(nameof(options));
            logger.ThrowIfNull(nameof(logger));
            LoggerOptionBuilder.UseLogger(() => new NLogProvider(logger));
            return options;
        }
    }
}