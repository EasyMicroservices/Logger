using EasyMicroservices.Logger.Log4net.Providers;
using EasyMicroservices.Logger.Options;
using log4net;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class Log4netExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public static LoggerOption UseLog4net(this LoggerOption options, ILog log)
        {
            options.ThrowIfNull(nameof(options));
            log.ThrowIfNull(nameof(log));
            LoggerOptionBuilder.UseLogger(() => new Log4netProvider(log));
            return options;
        }
    }
}
