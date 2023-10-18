using EasyMicroservices.Logger.Providers;
using EasyMicroservices.ServiceContracts;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMicroservices.Logger.Serilog.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public class SerilogProvider : BaseProvider
    {
        readonly global::Serilog.Core.Logger _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerConfiguration"></param>
        public SerilogProvider(LoggerConfiguration loggerConfiguration)
        {
            _logger = loggerConfiguration.CreateLogger();
        }

        MessageContract Log(object[] args, Action<Exception, string, object[]> action1, Action<string, object[]> action2)
        {
            var extracted = Extract(args);
            AddNotExistItems(extracted);
            if (extracted.HasExceptions)
                action1(extracted.Exceptions.First(), extracted.Messages.First(), extracted.Objects);
            else
                action2(extracted.Messages.First(), extracted.Objects);
            return (MessageContract)true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public override MessageContract Verbose(params object[] args)
        {
            return Log(args, _logger.Verbose, _logger.Verbose);
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
            return Log(args, _logger.Information, _logger.Information);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override MessageContract Warning(params object[] args)
        {
            return Log(args, _logger.Warning, _logger.Warning);
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
