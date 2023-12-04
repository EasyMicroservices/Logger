using EasyMicroservices.Logger.Serilog.Providers;
using Serilog;

namespace EasyMicroservices.Logger.Tests.Providers
{
    public class SerilogProviderTest : BaseProviderTest
    {
        public SerilogProviderTest() : base(new SerilogProvider(new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("serilog.txt")))
        {
        }
    }

    public class SerilogProviderAsyncTest : BaseProviderAsyncTest
    {
        public SerilogProviderAsyncTest() : base(new SerilogProvider(new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("serilog.txt")))
        {
        }
    }
}
