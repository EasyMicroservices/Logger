using EasyMicroservices.ServiceContracts;
using System.Threading.Tasks;

namespace EasyMicroservices.Logger.Interfaces
{
    /// <summary>
    /// General logger define here
    /// </summary>
    public interface ILoggerProvider
    {
        /// <summary>
        ///  Verbose level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<MessageContract> Verbose(params object[] args);

        /// <summary>
        /// Debug level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<MessageContract> Debug(params object[] args);

        /// <summary>
        /// Information level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<MessageContract> Information(params object[] args);

        /// <summary>
        /// Warning level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<MessageContract> Warning(params object[] args);

        /// <summary>
        /// Error level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<MessageContract> Error(params object[] args);

        /// <summary>
        /// Fatal level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<MessageContract> Fatal(params object[] args);
    }
}
