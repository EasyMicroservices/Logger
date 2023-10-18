using EasyMicroservices.Logger.Providers;
using EasyMicroservices.ServiceContracts;
using log4net;
using System;
using System.Linq;

namespace EasyMicroservices.Logger.Log4net.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public class Log4netProvider : BaseProvider
    {
        readonly ILog _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public Log4netProvider(ILog logger)
        {
            _logger = logger;
        }

        MessageContract Log(object[] args, Action<object, Exception> action1, Action<object> action2)
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
            return Log(args, _logger.Debug, _logger.Debug);
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