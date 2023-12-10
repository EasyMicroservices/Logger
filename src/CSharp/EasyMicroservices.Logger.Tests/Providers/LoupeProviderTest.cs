using EasyMicroservices.Logger.Loupe.Providers;

namespace EasyMicroservices.Logger.Tests.Providers;

public class LoupeProviderTest : BaseProviderTest
{
    public LoupeProviderTest() : base(new LoupeProvider())
    {
    }
}

public class LoupeProviderAsyncTest : BaseProviderAsyncTest
{
    public LoupeProviderAsyncTest() : base(new LoupeProvider())
    {
    }
}