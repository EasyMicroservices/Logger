using EasyMicroservices.Logger.Loupe.Providers;
using EasyMicroservices.Logger.Options;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class LoupeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static LoggerOption UseLoupe(this LoggerOption options)
        {
            options.ThrowIfNull(nameof(options));
            LoggerOptionBuilder.UseLogger(() => new LoupeProvider());
            return options;
        }
    }
}
