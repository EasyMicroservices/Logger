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
    public abstract class BaseProvider : ILoggerProviderAsync
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
        public virtual Task<MessageContract> DebugAsync(params object[] args)
        {
            return Task.FromResult(Debug(args));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual Task<MessageContract> ErrorAsync(params object[] args)
        {
            return Task.FromResult(Error(args));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<MessageContract> FatalAsync(params object[] args)
        {
            return Task.FromResult(Fatal(args));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<MessageContract> InformationAsync(params object[] args)
        {
            return Task.FromResult(Information(args));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<MessageContract> VerboseAsync(params object[] args)
        {
            return Task.FromResult(Verbose(args));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<MessageContract> WarningAsync(params object[] args)
        {
            return Task.FromResult(Warning(args));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public abstract MessageContract Verbose(params object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public abstract MessageContract Debug(params object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public abstract MessageContract Information(params object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public abstract MessageContract Warning(params object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public abstract MessageContract Error(params object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public abstract MessageContract Fatal(params object[] args);
    }
}
