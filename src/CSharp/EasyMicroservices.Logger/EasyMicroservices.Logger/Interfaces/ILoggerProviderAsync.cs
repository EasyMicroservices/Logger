using EasyMicroservices.ServiceContracts;
using System.Threading.Tasks;

namespace EasyMicroservices.Logger.Interfaces
{
    /// <summary>
    /// General logger define here
    /// </summary>
    public interface ILoggerProviderAsync
    {
        /// <summary>
        ///  Verbose level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<MessageContract> VerboseAsync(params object[] args);

        /// <summary>
        /// Debug level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<MessageContract> DebugAsync(params object[] args);

        /// <summary>
        /// Information level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<MessageContract> InformationAsync(params object[] args);

        /// <summary>
        /// Warning level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<MessageContract> WarningAsync(params object[] args);

        /// <summary>
        /// Error level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<MessageContract> ErrorAsync(params object[] args);

        /// <summary>
        /// Fatal level log
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<MessageContract> FatalAsync(params object[] args);
    }
}
