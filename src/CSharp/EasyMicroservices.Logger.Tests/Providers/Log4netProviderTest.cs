using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMicroservices.Logger.Log4net.Providers;
using log4net;

namespace EasyMicroservices.Logger.Tests.Providers
{
    public class Log4netProviderTest : BaseProviderTest
    {
        public Log4netProviderTest() : base(new Log4netProvider(LogManager.GetLogger(typeof(BaseProviderTest))))
        {
        }
    }
    public class Log4netProviderAsyncTest : BaseProviderAsyncTest
    {
        public Log4netProviderAsyncTest() : base(new Log4netProvider(LogManager.GetLogger(typeof(BaseProviderTest))))
        {
        }
    }
}
