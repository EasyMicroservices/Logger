using EasyMicroservices.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.Logger.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILoggerProvider
    {
        /// <summary>
        ///  Verbose level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        MessageContract Verbose(params object[] args);

        /// <summary>
        /// Debug level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        MessageContract Debug(params object[] args);

        /// <summary>
        /// Information level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        MessageContract Information(params object[] args);

        /// <summary>
        /// Warning level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        MessageContract Warning(params object[] args);

        /// <summary>
        /// Error level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        MessageContract Error(params object[] args);

        /// <summary>
        /// Fatal level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        MessageContract Fatal(params object[] args);
    }
}
