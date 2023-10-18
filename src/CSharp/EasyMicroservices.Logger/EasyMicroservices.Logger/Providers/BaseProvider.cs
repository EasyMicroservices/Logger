using EasyMicroservices.Logger.Interfaces;
using EasyMicroservices.Logger.Models;
using EasyMicroservices.ServiceContracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMicroservices.Logger.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseProvider : ILoggerProvider
    {
        internal ExtractedLogInfo Extract(params object[] args)
        {
            args.ThrowIfNullOrEmpty(nameof(args));
            return new ExtractedLogInfo()
            {
                Exceptions = args.Where(x => x is Exception).Cast<Exception>().ToArray(),
                Messages = args.Where(x => x is string).Cast<string>().ToArray(),
                Objects = args.Where(x => x is not Exception && x is not string).ToArray(),
            };
        }

        internal void AddNotExistItems(ExtractedLogInfo extracted)
        {
            if (extracted.Messages.IsEmpty())
                extracted.Messages = new string[] { "Empty" };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public abstract Task<MessageContract> Debug(params object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public abstract Task<MessageContract> Error(params object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public abstract Task<MessageContract> Fatal(params object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public abstract Task<MessageContract> Information(params object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public abstract Task<MessageContract> Verbose(params object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public abstract Task<MessageContract> Warning(params object[] args);
    }
}
