using EasyMicroservices.Logger.Logary.Providers;

namespace EasyMicroservices.Logger.Tests.Providers;
public class LogaryProviderTest : BaseProviderTest
{
    public LogaryProviderTest() : base(new LogaryProvider())
    {
    }
}

public class LogaryProviderAsyncTest : BaseProviderAsyncTest
{
    public LogaryProviderAsyncTest() : base(new LogaryProvider())
    {
    }
}