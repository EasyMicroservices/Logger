using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMicroservices.Logger.NLog.Providers;
using NLog;

namespace EasyMicroservices.Logger.Tests.Providers
{
    public class NLogProviderTest : BaseProviderTest
    {
        public NLogProviderTest() : base(new NLogProvider(LogManager.GetCurrentClassLogger()))
        {
        }
    }
}
