using EasyMicroservices.Logger.Sentry.Providers;
using EasyMicroservices.Logger.Options;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class SentryExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static LoggerOption UseSentry(this LoggerOption options)
        {
            options.ThrowIfNull(nameof(options));
            LoggerOptionBuilder.UseLogger(() => new SentryProvider());
            return options;
        }
    }
}
