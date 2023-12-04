using EasyMicroservices.Logger.Providers;
using EasyMicroservices.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.Logger.NLog.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public class NLogProvider : BaseProvider
    {
        readonly global::NLog.Logger _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public NLogProvider(global::NLog.Logger logger)
        {
            _logger = logger;
        }

        MessageContract Log(object[] args, Action<string, Exception> action1, Action<string> action2)
        {
            var extracted = Extract(args);
            AddNotExistItems(extracted);
            if (extracted.HasExceptions)
                action1(extracted.Messages.First(), extracted.Exceptions.First());
            else
                action2(extracted.Messages.First());
            return (MessageContract)true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public override MessageContract Verbose(params object[] args)
        {
            return Log(args, _logger.Trace, _logger.Trace);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override MessageContract Debug(params object[] args)
        {
            return Log(args, _logger.Debug, _logger.Debug);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override MessageContract Information(params object[] args)
        {
            return Log(args, _logger.Info, _logger.Info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override MessageContract Warning(params object[] args)
        {
            return Log(args, _logger.Warn, _logger.Warn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public override MessageContract Error(params object[] args)
        {
            return Log(args, _logger.Error, _logger.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public override MessageContract Fatal(params object[] args)
        {
            return Log(args, _logger.Fatal, _logger.Fatal);
        }
    }
}