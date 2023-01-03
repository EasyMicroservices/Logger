namespace EasyMicroservices.Logger.Interfaces
{
    /// <summary>
    /// General logger define here
    /// </summary>
    public interface IEasyLogger
    {
        /// <summary>
        ///  Verbose level log
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string Verbose(string message);

        /// <summary>
        /// Debug level log
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string Debug(string message);

        /// <summary>
        /// Information level log
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string Information(string message);

        /// <summary>
        /// Warning level log
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string Warning(string message);

        /// <summary>
        /// Error level log
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string Error(string message);

        /// <summary>
        /// Fatal level log
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string Fatal(string message);
    }
}
