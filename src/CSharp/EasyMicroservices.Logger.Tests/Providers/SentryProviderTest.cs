using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMicroservices.Logger.Sentry.Providers;

namespace EasyMicroservices.Logger.Tests.Providers;

public class SentryProviderTest : BaseProviderTest
{
    public SentryProviderTest() : base(new SentryProvider())
    {
    }
}

public class SentryProviderAsyncTest : BaseProviderAsyncTest
{
    public SentryProviderAsyncTest() : base(new SentryProvider())
    {
    }
}